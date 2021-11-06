#region Using Normal
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.CodeDom;
using System.Collections;
using System.Configuration;
using System.Deployment;
using System.Dynamic;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Resources;
using System.Runtime;
using System.Security;
using System.Timers;
using System.Web;
using System.Windows;
using System.Xml;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.DesignerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Hosting;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Windows.Markup;
using System.Windows.Input;
using System.Net.Cache;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO.Compression;
#endregion
using NBT_Tag_Code_Maker;
using DiscordRpcDemo;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using NBT_Tag_Code_Maker.Properties;

namespace NBT_Tag_Code_Maker
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        public string code;

        private void Form1_Load(object sender, EventArgs e)
        {
            #region List details
            potionList.View = View.Details;
            enchantmentList.View = View.Details;
            attributeList.View = View.Details;
            #endregion

            #region Discord RPC
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("853039518257119253", ref this.handlers, true, null);
            this.presence.details = "Make a NBT tag code";
            this.presence.largeImageKey = "nbt_tag_code_maker_1024";
            this.presence.smallImageKey = "minecraft";
            this.presence.largeImageText = "NBT Tag Code Maker";
            this.presence.smallImageText = "Minecraft";
            DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long startTimestamp = (long)(DateTime.UtcNow - d).TotalSeconds;
            this.presence.startTimestamp = startTimestamp;
            DiscordRpc.UpdatePresence(ref this.presence);
            #endregion
        }

        #region Option
        private void creativeTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemPlace.Enabled = true;
            itemNumber.Enabled = true;
            itemID.Enabled = true;
            itemDamage.Enabled = true;
            unbreakable.Enabled = true;
            enchantment.Enabled = true;
            attribute.Enabled = true;
            make.Enabled = true;
            makeAndAdd.Enabled = true;
        }

        private void itemPlace_ValueChanged(object sender, EventArgs e)
        {

        }

        private void itemNumber_ValueChanged(object sender, EventArgs e)
        {

        }

        private void itemID_ValueChanged(object sender, EventArgs e)
        {
            if (itemID.Value == 373)
            {
                potionBox.Enabled = true;
                colorBox.Enabled = false;
            }
            else
            {
                if (itemID.Value == 438)
                {
                    potionBox.Enabled = true;
                    colorBox.Enabled = false;
                }
                else
                {
                    if (itemID.Value == 441)
                    {
                        potionBox.Enabled = true;
                        colorBox.Enabled = false;
                    }
                    else
                    {
                        if (itemID.Value == 298)
                        {
                            potionBox.Enabled = false;
                            colorBox.Enabled = true;
                        }
                        else
                        {
                            if (itemID.Value == 299)
                            {
                                potionBox.Enabled = false;
                                colorBox.Enabled = true;
                            }
                            else
                            {
                                if (itemID.Value == 300)
                                {
                                    potionBox.Enabled = false;
                                    colorBox.Enabled = true;
                                }
                                else
                                {
                                    if (itemID.Value == 301)
                                    {
                                        potionBox.Enabled = false;
                                        colorBox.Enabled = true;
                                    }
                                    else
                                    {
                                        if (itemID.Value == 358)
                                        {
                                            potionBox.Enabled = false;
                                            colorBox.Enabled = true;
                                        }
                                        else
                                        {
                                            colorBox.Enabled = false;
                                            potionBox.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            presence.state = "Item: " + itemID.Value + ":" + itemDamage.Value;
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void itemDamage_ValueChanged(object sender, EventArgs e)
        {
            presence.state = "Item: " + itemID.Value + ":" + itemDamage.Value;
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void unbreakable_CheckedChanged(object sender, EventArgs e)
        {
            /*if (unbreakable.Checked)
            {
                itemDamage.Enabled = false;
            }
            else
            {
                itemDamage.Enabled = true;
            }*/
        }

        private void enchantment_CheckedChanged(object sender, EventArgs e)
        {
            if (enchantment.Checked)
            {
                enchantmentBox.Enabled = true;
            }
            else
            {
                enchantmentBox.Enabled = false;
            }
        }

        private void attribute_CheckedChanged(object sender, EventArgs e)
        {
            if (attribute.Checked)
            {
                attributeBox.Enabled = true;
            }
            else
            {
                attributeBox.Enabled = false;
            }
        }

        private void info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item ID info :\r\n" +
                "\r\n9 : Still water" +
                "\r\n11 : Still lava" +
                "\r\n34 : Piston head" +
                "\r\n55 : Redstone wire" +
                "\r\n104 : Pumpkim stem" +
                "\r\n105 : Melon stem" +
                "\r\n122 : Dragon egg" +
                "\r\n132 : Tripwire" +
                "\r\n137 : Command block" +
                "\r\n210 : Repeating command block" +
                "\r\n211 : Chain command block" +
                "\r\n166 : Barrier" +
                "\r\n2255 : debug_fourj_item (fake barrier block)" +
                "\r\n276 : Diamond sword" +
                "\r\n454 : Trident" +
                "\r\n456 : Turtle helmet" +
                "\r\n298 : Leather helmet" +
                "\r\n299 : Leather tunic" +
                "\r\n300 : Leather pants" +
                "\r\n301 : Leather boots" +
                "\r\n373 : Potion" +
                "\r\n438 : Splash potion" +
                "\r\n441 : Lingering potion" +
                "\r\n1086 : Full oak wood" +
                "\r\n1081 : Full spruce wood" +
                "\r\n1082 : Full birch wood" +
                "\r\n1083 : Full jungle wood" +
                "\r\n1084 : Full acacia wood" +
                "\r\n1085 : Full dark oak wood" +
                "\r\n", "NBT Tag Code Maker");
        }

        private void itemIdList_Click(object sender, EventArgs e)
        {
            Process.Start("https://minecraft-ids.grahamedgecombe.com/");
        }
        #endregion

        #region Potion
        private void addPotion_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = potionList.Items.Add(potionEffectText.Text);
            listViewItem.SubItems.Add(potionLevel.Value.ToString());
            listViewItem.SubItems.Add(potionDuration.Value.ToString());
        }
        #endregion

        #region Enchantment
        private void addEnchantment_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = enchantmentList.Items.Add(enchantmentText.Text);
            listViewItem.SubItems.Add(enchantmentLevel.Value.ToString());
        }
        #endregion

        #region Attribute
        private void addAttribute_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = attributeList.Items.Add(attributeText.Text);
            listViewItem.SubItems.Add(attributeLevel.Value.ToString());
        }
        #endregion

        #region Color
        private void red_ValueChanged(object sender, EventArgs e)
        {
            colorPanel.BackColor = Color.FromArgb((int)red.Value, (int)green.Value, (int)blue.Value);
            htmlValue.Text = ColorTranslator.ToHtml(colorPanel.BackColor);
        }

        private void green_ValueChanged(object sender, EventArgs e)
        {
            colorPanel.BackColor = Color.FromArgb((int)red.Value, (int)green.Value, (int)blue.Value);
            htmlValue.Text = ColorTranslator.ToHtml(colorPanel.BackColor);
        }

        private void blue_ValueChanged(object sender, EventArgs e)
        {
            colorPanel.BackColor = Color.FromArgb((int)red.Value, (int)green.Value, (int)blue.Value);
            htmlValue.Text = ColorTranslator.ToHtml(colorPanel.BackColor);
        }

        private void htmlValue_TextChanged(object sender, EventArgs e)
        {
            //Change le panel de couleurs
            colorPanel.BackColor = ColorTranslator.FromHtml(htmlValue.Text);

            //Désactive les évenement
            red.ValueChanged -= red_ValueChanged;
            green.ValueChanged -= green_ValueChanged;
            blue.ValueChanged -= blue_ValueChanged;

            //Décortique la valeur html
            red.Value = int.Parse(htmlValue.Text.Substring(1, 2), NumberStyles.HexNumber);
            green.Value = int.Parse(htmlValue.Text.Substring(3, 2), NumberStyles.HexNumber);
            blue.Value = int.Parse(htmlValue.Text.Substring(5, 2), NumberStyles.HexNumber);

            //Active les évenement
            red.ValueChanged += red_ValueChanged;
            green.ValueChanged += green_ValueChanged;
            blue.ValueChanged += blue_ValueChanged;
        }
        #endregion

        private static string convertToHex(int HexValue)
        {
            string result;
            if (HexValue < 0)
            {
                result = Convert.ToString(HexValue, 16);
            }
            else
            {
                if (HexValue < 16)
                {
                    result = "0000000" + Convert.ToString(HexValue, 16);
                }
                else
                {
                    if (HexValue < 256)
                    {
                        result = "000000" + Convert.ToString(HexValue, 16);
                    }
                    else
                    {
                        if (HexValue < 4096)
                        {
                            result = "00000" + Convert.ToString(HexValue, 16);
                        }
                        else
                        {
                            if (HexValue < 65536)
                            {
                                result = "0000" + Convert.ToString(HexValue, 16);
                            }
                            else
                            {
                                if (HexValue < 1048576)
                                {
                                    result = "000" + Convert.ToString(HexValue, 16);
                                }
                                else
                                {
                                    if (HexValue < 16777216)
                                    {
                                        result = "00" + Convert.ToString(HexValue, 16);
                                    }
                                    else
                                    {
                                        if (HexValue < 268435456)
                                        {
                                            result = "0" + Convert.ToString(HexValue, 16);
                                        }
                                        else
                                        {
                                            result = Convert.ToString(HexValue, 16);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void makeCode()
        {
            #region Creative tab
            string CreativeTabAddress;

            if (creativeTab.SelectedIndex == 0)
            {
                CreativeTabAddress = "10A0A6C0";
            }
            else
            {
                if (creativeTab.SelectedIndex == 1)
                {
                    CreativeTabAddress = "10A0A6D0";
                }
                else
                {
                    if (creativeTab.SelectedIndex == 2)
                    {
                        CreativeTabAddress = "10A0A700";
                    }
                    else
                    {
                        if (creativeTab.SelectedIndex == 3)
                        {
                            CreativeTabAddress = "10A0A710";
                        }
                        else
                        {
                            if (creativeTab.SelectedIndex == 4)
                            {
                                CreativeTabAddress = "10A0A720";
                            }
                            else
                            {
                                if (creativeTab.SelectedIndex == 5)
                                {
                                    CreativeTabAddress = "10A0A770";
                                }
                                else
                                {
                                    MessageBox.Show("You have to choose a creative tab !", "NBT Tag Code Maker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            code =
                "30000000 109DF84C" +
                "\r\n10000000 50000000" +
                "\r\n10120001 " + convertToHex((int)itemID.Value * 4);

            code = code +
                "\r\n30000000 " + CreativeTabAddress;
            #endregion

            #region Item
            code = code +
                "\r\n10000000 50000000" +
                "\r\n31000000 " + convertToHex((int)(itemPlace.Value - 1) * 4) +
                "\r\n30100000 00000000" +
                "\r\n10000000 50000000" +
                "\r\n11120001 00000014" +
                "\r\n0012000C " + convertToHex((int)itemNumber.Value) +
                "\r\n00120020 " + convertToHex((int)itemDamage.Value) +
                "\r\n00120018 12000000" +
                "\r\nD0000000 DEADCAFE" +

                "\r\n0100001C 12000000" +
                "\r\n1058FA54 00A8A598" +
                "\r\n00000011 00000001" +
                "\r\n3F800000 00000011" +
                "\r\n12000030 000000FF" +
                "\r\n30000000 12000018" +
                "\r\n10000000 50000000" +
                "\r\n00120044 120000D4" +
                "\r\n01000044 120000A0";
            #endregion

            #region Unbreakable
            if (unbreakable.Checked)
            {
                code = code +
                    "\r\n1056415C 01000000" +
                    "\r\n00000000 00000000";
            }
            else
            {
                code = code +
                    "\r\n1056415C 00000000" +
                    "\r\n00000000 00000000";
            }
            #endregion

            #region Unbreakable and color function
            code = code +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 120000E0" +
                "\r\n00000000 00000017" +
                "\r\n120000A0 12000134" +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000018 120000E0" +
                "\r\n0055006E 00620072" +//Un br
                "\r\n00650061 006B0061" +//ea ka
                "\r\n0062006C 00650000" +//bl e
                "\r\n00000000 000000FF" +
                "\r\n01000030 12000110" +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 12000140" +
                "\r\n00000000 00000017" +
                "\r\n12001000 12000184" +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000014 12000140" +
                "\r\n00640069 00730070" +//di sp
                "\r\n006C0061 00790000" +//la y
                "\r\n00000000 000000FF" +
                "\r\n0100001C 12001000" +
                "\r\n1058FA54 00A8A598" +
                "\r\n00000011 00000001" +
                "\r\n3F800000 00000011" +
                "\r\n12001030 000000FF" +
                "\r\n30000000 12001018" +
                "\r\n10000000 50000000" +
                "\r\n00120044 120010D4" +
                "\r\n01000044 120010A0" +
                "\r\n1065993C 00" + htmlValue.Text.Substring(1, 6) +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 120010E0" +
                "\r\n00000000 00000017" +
                "\r\n120010A0 00000000" +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF";
            #endregion

            #region Color
            #region Armor
            if (itemID.Value == 298)
            {
                code = code +
                    "\r\n0100000C 120010E0" +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            if (itemID.Value == 299)
            {
                code = code +
                    "\r\n0100000C 120010E0" +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            if (itemID.Value == 300)
            {
                code = code +
                    "\r\n0100000C 120010E0" +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            if (itemID.Value == 301)
            {
                code = code +
                    "\r\n0100000C 120010E0" +
                    "\r\n0063006F 006C006F" +//co lo
                    "\r\n00720000 000000FF";//r
            }
            #endregion

            #region Map
            if (itemID.Value == 358)//map
            {
                code = code +
                    "\r\n01000014 120010E0" +
                    "\r\n004D0061 00700043" +//Ma pC
                    "\r\n006F006C 006F0072" +//ol or
                    "\r\n00000000 000000FF";
            }
            #endregion

            if (colorBox.Enabled == false)
            {
                code = code +
                    "\r\n01000016 120010E0" +
                    "\r\n00000000 00000000" +
                    "\r\n00000000 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            #region Enchants, attributes and potions function
            code = code +
                "\r\n01000030 12000160" +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 12000190" +
                "\r\n00000000 00000017" +
                "\r\n12002000 120001D4" +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000014 12000190" +
                "\r\n0065006E 00630068" +//en ch
                "\r\n00000000 00000000" +
                "\r\n00000000 000000FF" +
                "\r\n01000030 120001B0" +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 120001E0" +
                "\r\n00000000 00000017" +
                "\r\n12005000 12000254" +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n01000026 120001E0" +
                "\r\n00410074 00740072" +//At tr
                "\r\n00690062 00750074" +//ib ut
                "\r\n0065004D 006F0064" +//eM od
                "\r\n00690066 00690065" +//if ie
                "\r\n00720073 000000FF" +//rs
                "\r\n01000030 12000230" +
                "\r\n11B0D430 0000AFB8" +
                "\r\n00000000 00000000" +
                "\r\n11B0D430 12000260" +
                "\r\n00000000 00000017" +
                "\r\n1200A000 00000000" +
                "\r\n00000000 0000003B" +
                "\r\n00000000 000000FF" +
                "\r\n0100002C 12000260" +
                "\r\n00430075 00730074" +//Cu st
                "\r\n006F006D 0050006F" +//om Po
                "\r\n00740069 006F006E" +//ti on
                "\r\n00450066 00660065" +//Ef fe
                "\r\n00630074 00730000" +//ec ts
                "\r\n00000000 000000FF";
            #endregion

            #region Enchantment
            if (enchantment.Checked)
            {
                code = code +
                "\r\n0100001C 12002000" +
                "\r\n1067DAF0 00000000" +
                "\r\n12002030 " + convertToHex(0x12002030 + enchantmentList.CheckedItems.Count * 4) +
                "\r\n" + convertToHex(0x12002030 + enchantmentList.CheckedItems.Count * 4) + " 0A000000" +
                "\r\n00000000 000000FF";

                int num2 = 0;
                int num3 = 0;
                string text7 = "";
                string enchantmentString = "";

                int i = 0;
                while (i < enchantmentList.Items.Count)//Execute la fonction tant i est plus petit que le nombre d'item dans enchant
                {
                    if (enchantmentList.Items[i].Checked)//Si l'item numéro i est checké
                    {
                        if (num2 % 2 == 0)
                        {
                            text7 = text7 + convertToHex(0x12002130 + num2 * 320) + " ";
                        }
                        else
                        {
                            text7 = text7 + convertToHex(0x12002130 + num2 * 320) + "\r\n";
                        }

                        #region Enchantment string
                        #region Armor
                        if (enchantmentList.Items[i].SubItems[0].Text == "Protection")
                        {
                            enchantmentString = "00000000";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Fire protection")
                        {
                            enchantmentString = "00000001";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Blast protection")
                        {
                            enchantmentString = "00000002";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Projectile protection")
                        {
                            enchantmentString = "00000003";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Respiration")
                        {
                            enchantmentString = "00000004";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Aqua affinity")
                        {
                            enchantmentString = "00000005";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Thorns")
                        {
                            enchantmentString = "00000006";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Depth strider")
                        {
                            enchantmentString = "00000007";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Frost walker")
                        {
                            enchantmentString = "00000008";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Binding curse")
                        {
                            enchantmentString = "00000009";
                        }
                        #endregion

                        #region Sword
                        if (enchantmentList.Items[i].SubItems[0].Text == "Sharpness")
                        {
                            enchantmentString = "00000010";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Smite")
                        {
                            enchantmentString = "00000011";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Bane of arthropods")
                        {
                            enchantmentString = "00000012";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Knockback")
                        {
                            enchantmentString = "00000013";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Fire aspect")
                        {
                            enchantmentString = "00000014";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Looting")
                        {
                            enchantmentString = "00000015";
                        }
                        #endregion

                        #region Tools
                        if (enchantmentList.Items[i].SubItems[0].Text == "Efficiency")
                        {
                            enchantmentString = "00000020";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Silk touch")
                        {
                            enchantmentString = "00000021";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Unbreaking")
                        {
                            enchantmentString = "00000022";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Fortune")
                        {
                            enchantmentString = "00000023";
                        }
                        #endregion

                        #region Bow
                        if (enchantmentList.Items[i].SubItems[0].Text == "Power")
                        {
                            enchantmentString = "00000030";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Punch")
                        {
                            enchantmentString = "00000031";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Flame")
                        {
                            enchantmentString = "00000032";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Infinity")
                        {
                            enchantmentString = "00000033";
                        }
                        #endregion

                        #region Rod
                        if (enchantmentList.Items[i].SubItems[0].Text == "Luck of the sea")
                        {
                            enchantmentString = "0000003D";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Lure")
                        {
                            enchantmentString = "0000003E";
                        }
                        #endregion

                        #region Trident
                        if (enchantmentList.Items[i].SubItems[0].Text == "Loayalty")
                        {
                            enchantmentString = "00000041";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Impaling")
                        {
                            enchantmentString = "00000042";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Riptide")
                        {
                            enchantmentString = "00000043";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Channeling")
                        {
                            enchantmentString = "00000044";
                        }
                        #endregion

                        #region Other
                        if (enchantmentList.Items[i].SubItems[0].Text == "Mending")
                        {
                            enchantmentString = "00000046";
                        }
                        if (enchantmentList.Items[i].SubItems[0].Text == "Vanishing curse")
                        {
                            enchantmentString = "00000047";
                        }
                        #endregion
                        #endregion

                        #region Level string
                        string enchantmentLevelString = convertToHex(int.Parse(enchantmentList.Items[i].SubItems[1].Text));
                        #endregion

                        code = code +
                            "\r\n0100001C " + convertToHex(0x12002130 + num3) +
                            "\r\n1058FA54 00A8A598" +
                            "\r\n00000011 00000001" +
                            "\r\n3F800000 00000011" +
                            "\r\n" + convertToHex(0x12002160 + num3) + " 000000FF" +
                            "\r\n30000000 " + convertToHex(0x12002148 + num3) +
                            "\r\n10000000 50000000" +
                            "\r\n00120044 " + convertToHex(0x12002204 + num3) +
                            "\r\n01000044 " + convertToHex(0x120021D0 + num3) +
                            "\r\n10748CF8 " + enchantmentLevelString.Substring(4, 4) + "0000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex(0x12002210 + num3) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex(0x120021D0 + num3) + " " + convertToHex(0x12002254 + num3) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex(0x12002210 + num3) +
                            "\r\n006C0076 006C0000" +//lv l
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex(0x12002220 + num3) +
                            "\r\n10748CF8 " + enchantmentString.Substring(4, 4) + "0000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex(0x12002260 + num3) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex(0x12002220 + num3) + " 00000000" +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex(0x12002260 + num3) +
                            "\r\n00690064 00000000" +//id
                            "\r\n00000000 000000FF";

                        num3 += 320;
                        num2++;
                    }
                    i++;
                }

                if (num2 % 2 == 1)
                {
                    code = code +
                        "\r\n0100" + convertToHex(enchantmentList.CheckedItems.Count * 4 + 8).Substring(4, 4) + " 12002030" +
                        "\r\n" + text7 + "00000000" +
                        "\r\n00000000 000000FF";
                }
                else
                {
                    code = code +
                        "\r\n0100" + convertToHex(enchantmentList.CheckedItems.Count * 4 + 4).Substring(4, 4) + " 12002030" +
                        "\r\n" + text7 +
                        "\r\n00000000 000000FF";
                }
            }
            else
            {
                code = code +
                    "\r\n0100000C 12002000" +
                    "\r\n1065993C 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            #region Attribute
            if (attribute.Checked)
            {
                code = code +
                    "\r\n0100001C 12005000" +
                    "\r\n1067DAF0 00000000" +
                    "\r\n12005030 " + convertToHex(0x12005030 + attributeList.CheckedItems.Count * 4) +
                    "\r\n" + convertToHex(0x12005030 + attributeList.CheckedItems.Count * 4) + " 0A000000" +
                    "\r\n00000000 000000FF";

                int num2 = 0;
                int num3 = 0;
                string text7 = "";
                string attributeString = "";

                int i = 0;
                while (i < attributeList.Items.Count)
                {
                    if (attributeList.Items[i].Checked)
                    {
                        if (num2 % 2 == 0)
                        {
                            text7 = text7 + convertToHex(0x12005130 + num2 * 336) + " ";
                        }
                        else
                        {
                            text7 = text7 + convertToHex(0x12005130 + num2 * 336) + "\r\n";
                        }

                        #region Attribute string
                        if (attributeList.Items[i].SubItems[0].Text == "Max health")
                        {
                            attributeString = "00000000";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Follow range")
                        {
                            attributeString = "00000001";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Knockback resistance")
                        {
                            attributeString = "00000002";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Mouvement speed")
                        {
                            attributeString = "00000003";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Attack damage")
                        {
                            attributeString = "00000004";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Horse jump strength")
                        {
                            attributeString = "00000005";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Zombie spawn reinforcements")
                        {
                            attributeString = "00000006";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Attack speed")
                        {
                            attributeString = "00000007";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Armor")
                        {
                            attributeString = "00000008";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Armor toughness")
                        {
                            attributeString = "00000009";
                        }
                        if (attributeList.Items[i].SubItems[0].Text == "Luck")
                        {
                            attributeString = "0000000A";
                        }
                        #endregion

                        #region Attribute level string
                        string[] attributeLevelString = BitConverter.GetBytes(double.Parse(attributeList.Items[i].SubItems[1].Text)).Select(delegate (byte a)
                        {
                            byte b = a;
                            return b.ToString("X2");
                        }).Reverse<string>().ToArray<string>();
                        #endregion

                        code = code +
                            "\r\n0100001C " + convertToHex(0x12005130 + num3) +
                            "\r\n1058FA54 00A8A598" +
                            "\r\n00000011 00000001" +
                            "\r\n3F800000 00000011" +
                            "\r\n" + convertToHex(0x12005160 + num3) + " 000000FF" +
                            "\r\n30000000 " + convertToHex(0x12005148 + num3) +
                            "\r\n10000000 50000000" +
                            "\r\n00120044 " + convertToHex(0x12005204 + num3) +
                            "\r\n01000044 " + convertToHex(0x120051D0 + num3) +
                            "\r\n1065993C " + attributeString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex(0x12005210 + num3) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex(0x120051D0 + num3) + " " + convertToHex(0x12005254 + num3) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex(0x12005210 + num3) +
                            "\r\n00490044 00000000" +//ID
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex(0x12005220 + num3) +
                            "\r\n105C76B4 00000000" +
                            "\r\n" + string.Join("", attributeLevelString).Substring(0, 8) + " 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex(0x12005260 + num3) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex(0x12005220 + num3) + " 00000000" +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000E " + convertToHex(0x12005260 + num3) +
                            "\r\n0041006D 006F0075" +//Am ou
                            "\r\n006E0074 000000FF";//nt

                        num3 += 336;
                        num2++;
                    }
                    i++;
                }

                if (num2 % 2 == 1)
                {
                    code = code +
                        "\r\n0100" + convertToHex(attributeList.CheckedItems.Count * 4 + 8).Substring(4, 4) + " 12005030" +
                        "\r\n" + text7 + "00000000" +
                        "\r\n00000000 000000FF";
                }
                else
                {
                    code = code +
                        "\r\n0100" + convertToHex(attributeList.CheckedItems.Count * 4 + 4).Substring(4, 4) + " 12005030" +
                        "\r\n" + text7 +
                        "\r\n00000000 000000FF";
                }
            }
            else
            {
                code = code +
                    "\r\n0100000C 12005000" +
                    "\r\n1065993C 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion

            #region Potion
            if (potionBox.Enabled == true)
            {
                code = code +
                    "\r\n0100001C 1200A000" +
                    "\r\n1067DAF0 00000000" +
                    "\r\n1200A030 " + convertToHex(0x1200A030 + potionList.CheckedItems.Count * 4) +
                    "\r\n" + convertToHex(0x1200A030 + potionList.CheckedItems.Count * 4) + " 0A000000" +
                    "\r\n00000000 000000FF";

                int num2 = 0;
                int num3 = 0;
                string text7 = "";
                string potionEffectString = "";

                int i = 0;
                while (i < potionList.Items.Count)
                {
                    if (potionList.Items[i].Checked)
                    {
                        if (num2 % 2 == 0)
                        {
                            text7 = text7 + convertToHex(0x1200A130 + num2 * 464) + " ";
                        }
                        else
                        {
                            text7 = text7 + convertToHex(0x1200A130 + num2 * 464) + "\r\n";
                        }

                        #region Potion effect string
                        if (potionList.Items[i].SubItems[0].Text == "Speed")
                        {
                            potionEffectString = "00000001";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Slowness")
                        {
                            potionEffectString = "00000002";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Haste")
                        {
                            potionEffectString = "00000003";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Mining fatigue")
                        {
                            potionEffectString = "00000004";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Strength")
                        {
                            potionEffectString = "00000005";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Instant health")
                        {
                            potionEffectString = "00000006";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Instant damage")
                        {
                            potionEffectString = "00000007";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Jump boost")
                        {
                            potionEffectString = "00000008";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Nausea")
                        {
                            potionEffectString = "00000009";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Regeneration")
                        {
                            potionEffectString = "0000000A";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Resistance")
                        {
                            potionEffectString = "0000000B";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Fire resistance")
                        {
                            potionEffectString = "0000000C";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Water breathing")
                        {
                            potionEffectString = "0000000D";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Invisibility")
                        {
                            potionEffectString = "0000000E";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Blindness")
                        {
                            potionEffectString = "0000000F";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Night vision")
                        {
                            potionEffectString = "00000010";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Hunger")
                        {
                            potionEffectString = "00000011";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Weakness")
                        {
                            potionEffectString = "00000012";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Poison")
                        {
                            potionEffectString = "00000013";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Wither")
                        {
                            potionEffectString = "00000014";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Health boost")
                        {
                            potionEffectString = "00000015";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Absorption")
                        {
                            potionEffectString = "00000016";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Saturation")
                        {
                            potionEffectString = "00000017";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Glowing")
                        {
                            potionEffectString = "00000018";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Levitation")
                        {
                            potionEffectString = "00000019";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Luck")
                        {
                            potionEffectString = "0000001A";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Bad luck")
                        {
                            potionEffectString = "0000001B";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Conduit power")
                        {
                            potionEffectString = "0000001C";
                        }
                        if (potionList.Items[i].SubItems[0].Text == "Slow falling")
                        {
                            potionEffectString = "0000001D";
                        }
                        /*if (potionList.Items[i].SubItems[0].Text == "Dolphin's grace")
                        {
                            potionEffectString = "0000001E";
                        }*/
                        #endregion

                        #region Potion level string
                        string potionLevelString = convertToHex(int.Parse(potionList.Items[i].SubItems[1].Text) - 1);
                        #endregion

                        #region Potion duration string
                        string potionDurationString = convertToHex(int.Parse(potionList.Items[i].SubItems[2].Text));
                        #endregion

                        code = code +
                            "\r\n0100001C " + convertToHex(0x1200A130 + num3) +
                            "\r\n1058FA54 00A8A598" +
                            "\r\n00000011 00000001" +
                            "\r\n3F800000 00000011" +
                            "\r\n" + convertToHex(0x1200A160 + num3) + " 000000FF" +
                            "\r\n30000000 " + convertToHex(0x1200A148 + num3) +
                            "\r\n10000000 50000000" +
                            "\r\n00120044 " + convertToHex(0x1200A204 + num3) +
                            "\r\n01000044 " + convertToHex(0x1200A1D0 + num3) +
                            "\r\n1065993C " + potionEffectString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex(0x1200A210 + num3) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex(0x1200A1D0 + num3) + " " + convertToHex(0x1200A254 + num3) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n0100000C " + convertToHex(0x1200A210 + num3) +
                            "\r\n00490064 00000000" +//ID
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex(0x1200A220 + num3) +
                            "\r\n1065993C " + potionDurationString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex(0x1200A260 + num3) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex(0x1200A220 + num3) + " " + convertToHex(0x1200A2C4 + num3) +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n01000014 " + convertToHex(0x1200A260 + num3) +
                            "\r\n00440075 00720061" +//Du ra
                            "\r\n00740069 006F006E" +//ti on
                            "\r\n00000000 000000FF" +
                            "\r\n01000044 " + convertToHex(0x1200A290 + num3) +
                            "\r\n1065993C " + potionLevelString +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 00000000" +
                            "\r\n00000000 00000000" +
                            "\r\n11B0D430 " + convertToHex(0x1200A2D0 + num3) +
                            "\r\n00000000 00000017" +
                            "\r\n" + convertToHex(0x1200A290 + num3) + " 00000000" +
                            "\r\n00000000 0000003B" +
                            "\r\n00000000 000000FF" +
                            "\r\n01000014 " + convertToHex(0x1200A2D0 + num3) +
                            "\r\n0041006D 0070006C" +//Am pl
                            "\r\n00690066 00690065" +//if ie
                            "\r\n00720000 000000FF";//r

                        num3 += 464;
                        num2++;
                    }
                    i++;
                }

                if (num2 % 2 == 1)
                {
                    code = code +
                        "\r\n0100" + convertToHex(potionList.CheckedItems.Count * 4 + 8).Substring(4, 4) + " 1200A030" +
                        "\r\n" + text7 + "00000000" +
                        "\r\n00000000 000000FF";
                }
                else
                {
                    code = code +
                        "\r\n0100" + convertToHex(potionList.CheckedItems.Count * 4 + 4).Substring(4, 4) + " 1200A030" +
                        "\r\n" + text7 +
                        "\r\n00000000 000000FF";
                }
            }
            else
            {
                code = code +
                    "\r\n0100000C 1200A000" +
                    "\r\n1065993C 00000000" +
                    "\r\n00000000 000000FF";
            }
            #endregion
        }

        private void make_Click(object sender, EventArgs e)
        {
            makeCode();
            codeText.Text = code;
        }

        private void makeAndAdd_Click(object sender, EventArgs e)
        {
            makeCode();
            codeText.Text = codeText.Text + "\r\n" + code;
        }

        private void copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(codeText.Text);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            codeText.ResetText();
        }

        private void channelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/c/nt-games-ytb");
        }
    }
}
