using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knapsack_cryptosystem
{
    public partial class GUI : Form
    {
        Knapsack knapsack;

        public GUI()
        {
            InitializeComponent();

            knapsack = new Knapsack();
            textBox_privateKey.Text = knapsack.getPrivateKeyString();
            textBox_publicKey.Text = knapsack.getPublicKeyString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_cipher.Text = knapsack.encrypt(textBox_plainText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_plainText.Text = knapsack.decrypt(knapsack.cipherToString(textBox_cipher.Text));
        }
    }
}
