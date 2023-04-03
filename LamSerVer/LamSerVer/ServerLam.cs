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

namespace LamSerVer
{
    public partial class ServerLam : Form
    {
        public ServerLam()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            MyConnect();
        }

        Socket server;
        List<Socket> clientList = new List<Socket>();
        IPAddress ipa;
        IPEndPoint ipend;
        int port = 2505;

        int pos = 0;
        Image imgFile;
        Image icon;
        String userName = "";
        String nameImg = "";

        private void MyConnect()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ipa = IPAddress.Any;

            ipend = new IPEndPoint(ipa, port);
            server.Bind(ipend);

            Thread thread = new Thread(new ThreadStart(() => {
                try
                {
                    while (true)
                    {
                        server.Listen(50);
                        Socket client = server.Accept();
                        clientList.Add(client);

                        ServerList.ipList.Add(client.LocalEndPoint.ToString());

                        ShowUserName(client);

                        check_lb.Items.Add("User: " + userName, CheckState.Unchecked);
                        ServerList.userList.Add(userName);

                        Thread tReceive = new Thread(ShowMessage);
                        tReceive.SetApartmentState(ApartmentState.STA);
                        tReceive.IsBackground = true;
                        tReceive.Start(client);
                    }
                }
                catch
                {
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ipend = new IPEndPoint(ipa, port);
                }
            }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        private void rtbShowChat_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int count = 0;
            int dem = 0;
            Boolean checkedItem = false;

            foreach (Socket sk in clientList)
            {
                if (check_lb.GetItemCheckState(dem) == CheckState.Checked)
                {
                    checkedItem = true;
                }
                dem++;
            }

            if (checkedItem)
            {
                DateTime now = DateTime.Now;
                String timer = "Server: " + now.ToString("hh:mm");
                if (nameImg != "")
                {
                    AddMessage(timer.ToString());
                    ImageFile(nameImg);

                    Clipboard.SetImage(imgFile);
                    rtb_Main.Paste();
                    rtb_Main.AppendText("\n");
                }
                else if (icon != null)
                {
                    AddMessage(timer.ToString());

                    Clipboard.SetImage(icon);
                    rtb_Main.Paste();
                    rtb_Main.AppendText("\n");

                }
                else if (rtb_Send.Text != String.Empty)
                {
                    AddMessage(timer.ToString());
                    AddMessage(rtb_Send.Text);
                }
                else if (rtb_Send.Text == String.Empty)
                {
                    MessageBox.Show("Nhập nội dung!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn người nhận!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            foreach (Socket sk in clientList)
            {
                if (check_lb.GetItemCheckState(count) == CheckState.Checked)
                {
                    SendServer(sk);
                }
                count++;
            }

            rtb_Send.Clear();
            icon = null;
            nameImg = "";
        }

        private void SendServer(Socket clientt)
        {
            if (nameImg != "")
            {
                ImageFile(nameImg);
                MySendImage(imgFile, clientt);
            }
            else if (icon != null)
            {
                MySendImage(icon, clientt);
            }
            else if (rtb_Send.Text != String.Empty)
            {
                MySend(rtb_Send.Text, clientt);
            }
            else if (rtb_Send.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng nội dung!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ImageFile(String fileName)
        {
            imgFile = Image.FromFile(fileName);
        }

        private void MySend(String s, Socket client)
        {
            byte[] data = new byte[1024 * 10000];
            data = MySerialize(s);
            client.Send(data);
        }

        private void MySendImage(Image img, Socket client)
        {
            byte[] data = new byte[1024 * 10000];
            data = SerializeImage(img);
            client.Send(data);
        }

        private string MyDeserialize(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }

        private String DeserializeUserName(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return (String)formatter.Deserialize(stream);
        }

        private byte[] MySerialize(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

        public byte[] SerializeImage(Image img)
        {
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Png);
            return stream.ToArray();

        }

        private Image MyDeserializeImage(byte[] data)
        {
            MemoryStream MStream = new MemoryStream(data);
            Image img = Image.FromStream(MStream);
            return img;
        }

        private void MyClose(Socket client)
        {
            client.Close();
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

        public void ShowMessage(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 10000];
                    client.Receive(data);

                    String userNameSend = "name";

                    for (int i = 0; i < clientList.Count; i++)
                    {
                        if (ServerList.ipList[i].ToString().Equals(client.LocalEndPoint.ToString()))
                        {
                            userNameSend = ServerList.userList[i];
                        }
                    }

                    DateTime now = DateTime.Now;
                    String timeLine = userNameSend + ": " + now.ToString("hh:mm tt");

                    if (CheckImage(data))
                    {
                        AddMessage(timeLine.ToString());

                        Image img = MyDeserializeImage(data);
                        Clipboard.SetImage(img);
                        rtb_Main.Paste();
                        rtb_Main.AppendText("\n");
                        foreach (Socket item in clientList)
                        {
                            if (item != client)
                            {
                                MySendImage(img, item);
                            }
                        }
                    }
                    else if (!CheckImage(data))
                    {
                        AddMessage(timeLine.ToString());
                        AddMessage((string)MyDeserialize(data));
                        foreach (Socket item in clientList)
                        {
                            if (item != client)
                            {
                                MySend((string)MyDeserialize(data), item);
                            }
                        }
                    }
                }
            }
            catch
            {
                clientList.Remove(client);
                MyClose(client);
            }
        }

        public void ShowUserName(Socket client)
        {
            try
            {
                byte[] data = new byte[1024 * 10000];
                client.Receive(data);

                userName = DeserializeUserName(data);
            }
            catch
            {
                userName = "null";
            }
        }

        private bool CheckImage(byte[] data)
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

        public void AddMessage(String s)
        {
            rtb_Main.AppendText(s);
            rtb_Main.AppendText("\n");
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
                    MessageBox.Show("Không thể load Icon!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                icon = imageList.Images[pos];
                Clipboard.SetImage(icon);
                rtb_Send.Paste();
            }
            catch
            {
                return;
            }
        }

        private void listIcon_MouseLeave(object sender, EventArgs e)
        {
            listIcon.Visible = false;
        }

        private void btn_File_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! Hiện chưa có tính năng này!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            
                
        }
    }
}
