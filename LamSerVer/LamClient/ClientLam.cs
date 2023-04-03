using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamClient
{
    public partial class ClientLam : Form
    {
        public ClientLam()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            MyConnect();
        }

        Socket client;
        List<Socket> clientList = new List<Socket>();
        IPAddress ipa;
        IPEndPoint ipend;
        int port = 2505;
        
        String nameImg = "";
        String userName = "";
        int pos = 0;
        Image icon;
        Image imgFile;

        public static Random ran = new Random();
        int ip = ran.Next(99);
        List<String> listIp = new List<String>();
        

        private void MyConnect()
        {
            ClientList.ipList.Add(ip);
            int countList = ClientList.ipList.Count;

            for (int i = 0; i < countList; i++)
            {
                while (ClientList.ipList[i] == ip)
                {
                    ClientList.ipList.RemoveAt(countList - 1);
                    int ip = ran.Next(99);
                    ClientList.ipList.Add(ip);
                }
            }

            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipa = IPAddress.Parse("127.0.0." + ip.ToString());
            ipend = new IPEndPoint(ipa, port);
            userName = ClientList.Username;

            try
            {
                client.Connect(ipend);
                SendUserName(userName);
                lb_Client.Text = userName;

                ClientList.userIpList.Add(client.LocalEndPoint.ToString());
                ClientList.endpointList.Add(userName);
            }
            catch
            {
                MessageBox.Show("Connect Error!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread threadReceive = new Thread(ShowMessage);
            threadReceive.SetApartmentState(ApartmentState.STA);
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            DateTime now = DateTime.Now;
            String timeLine = "Me: " + now.ToString("hh:mm");
            if (nameImg != "")
            {
                AddMessage(timeLine.ToString());
                ImageFile(nameImg);
                MySendImage(imgFile);

                Clipboard.SetImage(imgFile);
                rtb_Main.Paste();
                rtb_Main.AppendText("\n");
            }
            else if (icon != null)
            {
                AddMessage(timeLine.ToString());

                MySendImage(icon);

                Clipboard.SetImage(icon);
                rtb_Main.Paste();
                rtb_Main.AppendText("\n");

            }
            else if (rtb_Send.Text != String.Empty && nameImg == "")
            {
                AddMessage(timeLine.ToString());
                MySend(rtb_Send.Text);
                AddMessage(rtb_Send.Text);
            }
            else if (rtb_Send.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng nhập nội dung!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            rtb_Send.Clear();
            icon = null;
            nameImg = "";
        }

        private void MySend(String s)
        {
            byte[] data = new byte[1024 * 10000];
            data = MySerialize(s);
            client.Send(data);
        }

        private void MySendImage(Image img)
        {
            byte[] data = new byte[1024 * 10000];
            data = MyImageSerialize(img);
            client.Send(data);
        }

        private void SendUserName(object s)
        {
            byte[] data = new byte[1024 * 10000];

            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, s);

            data = stream.ToArray();
            client.Send(data);
        }

        private string MyDeserialize(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }
        private byte[] MySerialize(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

        public byte[] MyImageSerialize(Image img)
        {
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }

        public Image MyImageDeserialize(byte[] data)
        {
            MemoryStream MStream = new MemoryStream(data);
            Image img = Image.FromStream(MStream);
            return img;
        }

        private String DeserializeUserName(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return (String)formatter.Deserialize(stream);
        }

        private void ImageFile(String fileName)
        {
            imgFile = Image.FromFile(fileName);
        }

        public void ShowMessage()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 10000];
                    client.Receive(data);

                    DateTime now = DateTime.Now;
                    String timeLine = "Server: " + now.ToString("hh:mm");

                    if (CheckIMG(data))
                    {
                        AddMessage(timeLine.ToString());

                        Image img = MyImageDeserialize(data);
                        Clipboard.SetImage(img);
                        rtb_Main.Paste();
                        rtb_Main.AppendText("\n");
                    }
                    else if (!CheckIMG(data))
                    {
                        AddMessage(timeLine.ToString());
                        AddMessage(MyDeserialize(data));

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! Không thể nhận!!!" + ex, "Message !");
                MyClientClose();
            }
        }

        private bool CheckIMG(byte[] data)
        {
            try
            {
                MemoryStream stream = new MemoryStream(data);
                Image.FromStream(stream);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void MyClientClose()
        {
            client.Close();
            this.Close();
        }

        public void AddMessage(String s)
        {
            rtb_Main.AppendText(s);
            rtb_Main.AppendText("\n");
        }

        private void btn_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Image|*.bmp;*.jpg;*.gif;*.png;*.tif";
            img.ShowDialog();
            nameImg = img.FileName;
            if (nameImg != "")
            {
                Image image = Image.FromFile(nameImg);
                Clipboard.SetImage(image);
                rtb_Send.Paste();
            }
        }

        private void btn_Icon_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ASUS\Downloads\tessticon");
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    imageList.Images.Add(file.Name, Image.FromFile(file.FullName));
                }
                catch
                {
                    MessageBox.Show("Không load được list Icon!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            listIcon.View = View.LargeIcon;
            imageList.ImageSize = new Size(32, 32);
            listIcon.LargeImageList = imageList;

            for (int i = 0; i < imageList.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                listIcon.Items.Add(item);
            }

            listIcon.Visible = true;
        }

        private void listIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listIcon.FocusedItem == null) return;
                pos = listIcon.SelectedIndices[0];
                Clipboard.SetImage(imageList.Images[pos]);
                icon = imageList.Images[pos];
                rtb_Send.Paste();
            }
            catch
            {
                return;
            }
        }

        private void btn_File_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! Hiện chưa có tính năng này!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void listIcon_MouseLeave(object sender, EventArgs e)
        {
            listIcon.Visible = false;
        }

        private void XoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_Main.Cut();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            rtb_Main.Clear();
        }

        private void ChuyenTiepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = "";
            Clipboard.SetText(rtb_Main.SelectedText);
            text = Clipboard.GetText();
            if (!text.Equals(String.Empty))
            {
                byte[] data = new byte[1024 * 10000];
                data = MySerialize(text);
                client.Send(data);
            }
        }
    }
}
