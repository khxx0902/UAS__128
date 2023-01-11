using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS__128
{
    class Node
    {
        public int no_buku;
        public string jdl_buku;
        public string nm_pengarang;
        public int thn_terbit;
        public Node next;
        public Node prev;
    }
    class list
    {
        Node START;

        public list()
        {
            START = null;
        }
        public void addNode()
        {
            int no_buku;
            string jdl_buku;
            string nm_pengarang;
            int thn_terbit;

            Console.Write("Masukan Nomor Buku: ");
            no_buku = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan Judul Buku: ");
            jdl_buku = Console.ReadLine();
            Console.Write("Masukan Nama Pengarang: ");
            nm_pengarang = Convert.ToString(Console.ReadLine());
            Console.Write("Masukan Tahun Terbit: ");
            thn_terbit = Convert.ToInt32(Console.ReadLine());

            Node newNode = new Node();
            newNode.no_buku = no_buku;
            newNode.jdl_buku = jdl_buku;
            newNode.nm_pengarang = nm_pengarang;
            newNode.thn_terbit = thn_terbit;

            if (START == null || no_buku == START.no_buku)
            {
                if ((START != null) && (no_buku == START.no_buku))
                {
                    Console.WriteLine("Tidak Boleh duplikat");
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                current != null && no_buku >= current.no_buku;
                previous = current, current = current.next)
            {
                if (no_buku == current.no_buku)
                {
                    Console.WriteLine("Tidak Boleh Duplikat");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = current;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollkel, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (rollkel != current.thn_terbit))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void display()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("Data berdasarkan Tahun Terbit:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.no_buku + "" + currentNode.jdl_buku + "" + currentNode.nm_pengarang + " " + currentNode.thn_terbit + "\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            list dl = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("================================");
                    Console.WriteLine("1. Menambahkan Data");
                    Console.WriteLine("2. Mencari Data");
                    Console.WriteLine("3. Menampilkan Data");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\npilihlah(1 - 4): ");
                    Console.WriteLine("================================");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                dl.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (dl.listEmpty() == true)
                                {
                                    Console.WriteLine("Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("Masukan Tahun Terbit: ");
                                int thn_terbit = Convert.ToInt32(Console.ReadLine());
                                if (dl.search(thn_terbit, ref prev, ref curr) == false)
                                    Console.WriteLine("Data tidak ada");
                                else
                                {
                                    Console.WriteLine("Nomor Buku: " + curr.no_buku);
                                    Console.WriteLine("Judul Buku: " + curr.jdl_buku);
                                    Console.WriteLine("Nama Pengarang: " + curr.nm_pengarang);
                                    Console.WriteLine("Tahun Terbit: " + curr.thn_terbit);
                                }
                            }
                            break;
                        case '3':
                            {
                                dl.display();
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Mohon lihat ulang");
                }
            }
        }
    }
}

//2. Saya menggunakan algoritma Doubly Linked List dikarenakan lebih mudah untuk mengimplementasikannya terhadap soal yang diberikan. Terdapat data seperti no buku, judul buku,nama pengarang, dan tahun terbit yang memang saya rasa cocok dengan algorithma ini.
//Dan juga berdasarkan soal yang meminta kita untuk Menambah data,mencari data,mengurutkan,dan menampilkan data dari Nomer buku,Judul buku,Nama pengarang,dan Tahun terbit.

//3. TOP dan 

//4. rear dan front

//5.(a) Terdapat 4 kedalaman
//(b) Inorder = Data tersebut dimulai dari sebelah prorioritas kiri dulu lalu dilanjuti dengan data disebelah kanan dari induk itu sendiri

