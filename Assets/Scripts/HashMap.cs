using Employees;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tree {

    public class Node {
        public Workers.Employees data;
        public List<Workers.Employees> duplicates = new List<Workers.Employees>();

        public Node left;
        public Node right;
        public Node(Workers.Employees data) {
            this.data = data;
            left = null;
            right = null;
        }
    }


    public class Tree
    {
        private Node root;

        public void Insert(Workers.Employees data) {
            root = Add(root, data);
        }

        public bool Search(DateTime num) {
            return Find(root, num);
        }


        Node Add(Node node, Workers.Employees data) {

            if (node == null) {
                return new Node(data);
            }

            if (DateTime.Parse(data.lastEntranceInEngineRoom) == DateTime.Parse(node.data.lastEntranceInEngineRoom)) {
                node.duplicates.Add(data);
                return node;
            }

            if (DateTime.Parse(data.lastEntranceInEngineRoom) < DateTime.Parse(node.data.lastEntranceInEngineRoom)) {
                node.left = Add(node.left, data);
            } else {
                node.right = Add(node.right, data);
            }

            return node;
        }

        bool Find(Node node, DateTime num) {

            if(node == null) {
                return false;
            }

            if(DateTime.Parse(node.data.lastEntranceInEngineRoom) == num) {
                return true;
            }

            if(num < DateTime.Parse(node.data.lastEntranceInEngineRoom)) {
                return Find(node.left, num);

            }
            else {
                return Find(node.right, num);
            }
        }

    }

}
