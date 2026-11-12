using Employees;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tree {

    public class Node {
        public Workers.Employees data;
        public List<Workers.Employees> duplicates = new();

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

        public Node Search(DateTime num) {
            return Find(root, num);
        }

        public List<Workers.Employees> SearchRange(DateTime low, DateTime high) {
            List<Workers.Employees> result = new();

            if(low > high)
                return result;

            FindRange(root, low, high, result);

            return result;
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

        Node Find(Node node, DateTime num) {

            if (node == null) {
                return null;
            }

            if (DateTime.Parse(node.data.lastEntranceInEngineRoom) == num) {
                return node;
            }

            if (num < DateTime.Parse(node.data.lastEntranceInEngineRoom)) {
                return Find(node.left, num);
            }
            else {
                return Find(node.right, num);
            }
        }

        void FindRange(Node node, DateTime low, DateTime high, List<Workers.Employees> result) {

            if (node == null)
                return;

            DateTime currentDate = DateTime.Parse(node.data.lastEntranceInEngineRoom);

            if (currentDate > low) {
                FindRange(node.left, low, high, result);
            }

            if (currentDate >= low && currentDate <= high) {
                result.Add(node.data);

                for(int i = 0; i < node.duplicates.Count; i++) {
                    result.Add(node.duplicates[i]);
                }
            }

            if (currentDate < high) {
                FindRange(node.right, low, high, result);
            }
        }
    }
}
