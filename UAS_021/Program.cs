using System;
using System.Security;
using System.Xml.Linq;

namespace UAS_021
{
    class Node
    {
        public int NIM;
        public string Nama_Mahasiswa;
        public string Jenis_Kelamin;
        public string Kelas;
        public string Kota_Asal;
        public Node next;
        public Node prev;
    }
    class List
    {
        Node START;

        public List()
        {
            START = null;
        }

        public void AddNode()
        {
            int NIM;
            string Nama_Mhs;
            string Jenis_Kelamin;
            string Kelas;
            string Kota_Asal;

            Console.Write("Masukkan NIM: ");
            NIM = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Mahasiswa: ");
            Nama_Mhs = Console.ReadLine();
            Console.Write("Masukkan Jenis Kelamin: ");
            Jenis_Kelamin = Console.ReadLine();
            Console.Write("Masukkan Kelas: ");
            Kelas = Console.ReadLine();
            Console.Write("Masukkan Kota Asal: ");
            Kota_Asal = Console.ReadLine();

            Node newNode = new Node();
            newNode.NIM = NIM;
            newNode.Nama_Mahasiswa = Nama_Mhs;
            newNode.Jenis_Kelamin = Jenis_Kelamin;
            newNode.Kelas = Kelas;
            newNode.Kota_Asal = Kota_Asal;

            if (START == null || Kota_Asal == START.Kota_Asal)
            {
                if ((START != null) && (Kota_Asal == START.Kota_Asal))
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
                current != null && NIM >= current.NIM;
                previous = current, current = current.next)
            {
                if (Kota_Asal == current.Kota_Asal)
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
        public bool Search(string rollKA, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (rollKA != current.Kota_Asal))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }

        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void Display()
        {
            if (ListEmpty())
                Console.WriteLine("The List is Empty");
            else
            {
                Console.WriteLine("Data Beradasarkan Dari Kota Asal:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode = currentNode.next)
                    Console.WriteLine(currentNode.NIM + currentNode.Nama_Mahasiswa + currentNode.Jenis_Kelamin + currentNode.Kelas + currentNode.Kota_Asal + "\n");
            }
        }
        static void Main(string[] args)
        {
            List Angkatan = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu" +
                       "\n 1. Menambahkan Kota Asal" +
                       "\n 2. Mencari Kota Asal" +
                       "\n 3. Menampilkan Kota Asal" +
                       "\n 4. Exit" +
                       "\n Enter Your Choice (1 - 4):");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                Angkatan.AddNode();
                            }
                            break;
                        case '2':
                            {
                                if (Angkatan.ListEmpty() == true)
                                {
                                    Console.WriteLine("List Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("Masukkan Kota Asal: ");
                                string Kota_Asal = Console.ReadLine();
                                if (Angkatan.Search( Kota_Asal, ref prev, ref curr) == false)
                                    Console.WriteLine("Data tidak ada");
                                else
                                {
                                    Console.WriteLine("NIM: " + curr.NIM);
                                    Console.WriteLine("Nama Mahasiswa: " + curr.Nama_Mahasiswa);
                                    Console.WriteLine("Jenis Kelamin: " + curr.Jenis_Kelamin);
                                    Console.WriteLine("Kelas: " + curr.Kelas);
                                    Console.WriteLine("Kota Asal" + curr.Kota_Asal);
                                }
                            }
                            break;
                        case '3':
                            {
                                Angkatan.Display();
                            }
                            break;
                    }
                }
                 catch (Exception e)
                {
                    Console.WriteLine("Mohon Cek Ulang");
                }
            }
               
        }
    }
}
      

// 2. Saya menggunakkan algoritma jenis DoubleLinkedList karena menurut saya jenis algoritma ini yang paling saya yakin, mengerti dan menurut saya cocok dengan soal yang diberikan
// 3. FRONT dan REAR
// 4. Array adalah metode algoritma yang dimana telah ada indeks maksimal yang telah di tentukan
//    Linked List Adalah metode algoritma yang dimana tidak ada indeks maksimal yang ditentukan
// 5. A.Parent nya adalah data yang paling atas (20) sedangkan children adalah data cabang yang muncul dari data paling atas
//    B. Menggunakan Pre Order, karena cara membaca Pre Order adalah mulai dari paling atas (Root) lalu kemudian menuju ke bagian kiri, lalu menuju ke arah kanan