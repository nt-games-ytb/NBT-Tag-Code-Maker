﻿namespace NBT_Tag_Code_Maker
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.creativeTab = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.enchantment = new System.Windows.Forms.CheckBox();
            this.attribute = new System.Windows.Forms.CheckBox();
            this.itemPlace = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itemID = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.itemDamage = new System.Windows.Forms.NumericUpDown();
            this.unbreakable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.itemNumber = new System.Windows.Forms.NumericUpDown();
            this.potionBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.potionDuration = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.potionLevel = new System.Windows.Forms.NumericUpDown();
            this.addPotion = new System.Windows.Forms.Button();
            this.potionList = new System.Windows.Forms.ListView();
            this.columnPotionEffect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPotionLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPotionDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.potionEffectText = new System.Windows.Forms.ComboBox();
            this.enchantmentBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.enchantmentLevel = new System.Windows.Forms.NumericUpDown();
            this.addEnchantment = new System.Windows.Forms.Button();
            this.enchantmentList = new System.Windows.Forms.ListView();
            this.columnEnchantment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEnchantmentLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.enchantmentText = new System.Windows.Forms.ComboBox();
            this.optionBox = new System.Windows.Forms.GroupBox();
            this.info = new System.Windows.Forms.Button();
            this.itemIdList = new System.Windows.Forms.Button();
            this.attributeBox = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.attributeLevel = new System.Windows.Forms.NumericUpDown();
            this.addAttribute = new System.Windows.Forms.Button();
            this.attributeList = new System.Windows.Forms.ListView();
            this.columnAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAttributeLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label12 = new System.Windows.Forms.Label();
            this.attributeText = new System.Windows.Forms.ComboBox();
            this.codeText = new System.Windows.Forms.TextBox();
            this.colorBox = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.htmlValue = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.blue = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.red = new System.Windows.Forms.NumericUpDown();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.green = new System.Windows.Forms.NumericUpDown();
            this.make = new System.Windows.Forms.Button();
            this.makeAndAdd = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.copy = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.channelLink = new System.Windows.Forms.LinkLabel();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNumber)).BeginInit();
            this.potionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.potionDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.potionLevel)).BeginInit();
            this.enchantmentBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enchantmentLevel)).BeginInit();
            this.optionBox.SuspendLayout();
            this.attributeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attributeLevel)).BeginInit();
            this.colorBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            this.SuspendLayout();
            // 
            // creativeTab
            // 
            this.creativeTab.AutoCompleteCustomSource.AddRange(new string[] {
            "Building blocks",
            "Decoration",
            "Material",
            "Food",
            "Tools, weapons, armor",
            "Other"});
            this.creativeTab.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.creativeTab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.creativeTab.FormattingEnabled = true;
            this.creativeTab.Items.AddRange(new object[] {
            "Building blocks",
            "Decoration",
            "Material",
            "Food",
            "Tools, weapons, armor",
            "Other"});
            this.creativeTab.Location = new System.Drawing.Point(101, 15);
            this.creativeTab.Margin = new System.Windows.Forms.Padding(4);
            this.creativeTab.Name = "creativeTab";
            this.creativeTab.Size = new System.Drawing.Size(192, 24);
            this.creativeTab.TabIndex = 0;
            this.creativeTab.SelectedIndexChanged += new System.EventHandler(this.creativeTab_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Creative tab :";
            // 
            // enchantment
            // 
            this.enchantment.AutoSize = true;
            this.enchantment.Enabled = false;
            this.enchantment.Location = new System.Drawing.Point(10, 130);
            this.enchantment.Name = "enchantment";
            this.enchantment.Size = new System.Drawing.Size(104, 20);
            this.enchantment.TabIndex = 2;
            this.enchantment.Text = "Enchantment";
            this.enchantment.UseVisualStyleBackColor = true;
            this.enchantment.CheckedChanged += new System.EventHandler(this.enchantment_CheckedChanged);
            // 
            // attribute
            // 
            this.attribute.AutoSize = true;
            this.attribute.Enabled = false;
            this.attribute.Location = new System.Drawing.Point(158, 130);
            this.attribute.Name = "attribute";
            this.attribute.Size = new System.Drawing.Size(75, 20);
            this.attribute.TabIndex = 3;
            this.attribute.Text = "Attirbute";
            this.attribute.UseVisualStyleBackColor = true;
            this.attribute.CheckedChanged += new System.EventHandler(this.attribute_CheckedChanged);
            // 
            // itemPlace
            // 
            this.itemPlace.Enabled = false;
            this.itemPlace.Location = new System.Drawing.Point(101, 46);
            this.itemPlace.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemPlace.Name = "itemPlace";
            this.itemPlace.Size = new System.Drawing.Size(47, 22);
            this.itemPlace.TabIndex = 4;
            this.itemPlace.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemPlace.ValueChanged += new System.EventHandler(this.itemPlace_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Item place :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Item ID :";
            // 
            // itemID
            // 
            this.itemID.Enabled = false;
            this.itemID.Location = new System.Drawing.Point(101, 74);
            this.itemID.Maximum = new decimal(new int[] {
            2267,
            0,
            0,
            0});
            this.itemID.Name = "itemID";
            this.itemID.Size = new System.Drawing.Size(75, 22);
            this.itemID.TabIndex = 6;
            this.itemID.ValueChanged += new System.EventHandler(this.itemID_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Item damage :";
            // 
            // itemDamage
            // 
            this.itemDamage.Enabled = false;
            this.itemDamage.Location = new System.Drawing.Point(101, 102);
            this.itemDamage.Maximum = new decimal(new int[] {
            2267,
            0,
            0,
            0});
            this.itemDamage.Name = "itemDamage";
            this.itemDamage.Size = new System.Drawing.Size(75, 22);
            this.itemDamage.TabIndex = 8;
            this.itemDamage.ValueChanged += new System.EventHandler(this.itemDamage_ValueChanged);
            // 
            // unbreakable
            // 
            this.unbreakable.AutoSize = true;
            this.unbreakable.Enabled = false;
            this.unbreakable.Location = new System.Drawing.Point(182, 104);
            this.unbreakable.Name = "unbreakable";
            this.unbreakable.Size = new System.Drawing.Size(106, 20);
            this.unbreakable.TabIndex = 10;
            this.unbreakable.Text = "Unbreakable";
            this.unbreakable.UseVisualStyleBackColor = true;
            this.unbreakable.CheckedChanged += new System.EventHandler(this.unbreakable_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(155, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Item number :";
            // 
            // itemNumber
            // 
            this.itemNumber.Enabled = false;
            this.itemNumber.Location = new System.Drawing.Point(249, 48);
            this.itemNumber.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.itemNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemNumber.Name = "itemNumber";
            this.itemNumber.Size = new System.Drawing.Size(44, 22);
            this.itemNumber.TabIndex = 11;
            this.itemNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemNumber.ValueChanged += new System.EventHandler(this.itemNumber_ValueChanged);
            // 
            // potionBox
            // 
            this.potionBox.Controls.Add(this.label10);
            this.potionBox.Controls.Add(this.potionDuration);
            this.potionBox.Controls.Add(this.label7);
            this.potionBox.Controls.Add(this.potionLevel);
            this.potionBox.Controls.Add(this.addPotion);
            this.potionBox.Controls.Add(this.potionList);
            this.potionBox.Controls.Add(this.label6);
            this.potionBox.Controls.Add(this.potionEffectText);
            this.potionBox.Enabled = false;
            this.potionBox.ForeColor = System.Drawing.Color.White;
            this.potionBox.Location = new System.Drawing.Point(336, 20);
            this.potionBox.Name = "potionBox";
            this.potionBox.Size = new System.Drawing.Size(465, 138);
            this.potionBox.TabIndex = 13;
            this.potionBox.TabStop = false;
            this.potionBox.Text = "Potion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(7, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Duration :";
            // 
            // potionDuration
            // 
            this.potionDuration.Location = new System.Drawing.Point(104, 74);
            this.potionDuration.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.potionDuration.Name = "potionDuration";
            this.potionDuration.Size = new System.Drawing.Size(150, 22);
            this.potionDuration.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Level :";
            // 
            // potionLevel
            // 
            this.potionLevel.Location = new System.Drawing.Point(104, 46);
            this.potionLevel.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.potionLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.potionLevel.Name = "potionLevel";
            this.potionLevel.Size = new System.Drawing.Size(150, 22);
            this.potionLevel.TabIndex = 8;
            this.potionLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addPotion
            // 
            this.addPotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPotion.Location = new System.Drawing.Point(9, 102);
            this.addPotion.Name = "addPotion";
            this.addPotion.Size = new System.Drawing.Size(245, 30);
            this.addPotion.TabIndex = 4;
            this.addPotion.Text = "Add";
            this.addPotion.UseVisualStyleBackColor = true;
            this.addPotion.Click += new System.EventHandler(this.addPotion_Click);
            // 
            // potionList
            // 
            this.potionList.CheckBoxes = true;
            this.potionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPotionEffect,
            this.columnPotionLevel,
            this.columnPotionDuration});
            this.potionList.HideSelection = false;
            this.potionList.Location = new System.Drawing.Point(260, 15);
            this.potionList.Name = "potionList";
            this.potionList.Size = new System.Drawing.Size(200, 117);
            this.potionList.TabIndex = 0;
            this.potionList.UseCompatibleStateImageBehavior = false;
            // 
            // columnPotionEffect
            // 
            this.columnPotionEffect.Text = "Potion effect";
            this.columnPotionEffect.Width = 90;
            // 
            // columnPotionLevel
            // 
            this.columnPotionLevel.Text = "Level";
            this.columnPotionLevel.Width = 40;
            // 
            // columnPotionDuration
            // 
            this.columnPotionDuration.Text = "Duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Potion effect :";
            // 
            // potionEffectText
            // 
            this.potionEffectText.AutoCompleteCustomSource.AddRange(new string[] {
            "Speed",
            "Slowness",
            "Haste",
            "Mining fatigue",
            "Strength",
            "Instant health",
            "Instant damage",
            "Jump boost",
            "Nausea",
            "Regeneration",
            "Resistance",
            "Fire resistance",
            "Water breathing",
            "Invisibility",
            "Blindness",
            "Night vision",
            "Hunger",
            "Weakness",
            "Poison",
            "Wither",
            "Health boost",
            "Absorption",
            "Saturation",
            "Glowing",
            "Levitation",
            "Luck",
            "Bad luck",
            "Slow falling",
            "Conduit power"});
            this.potionEffectText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.potionEffectText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.potionEffectText.FormattingEnabled = true;
            this.potionEffectText.Items.AddRange(new object[] {
            "Speed",
            "Slowness",
            "Haste",
            "Mining fatigue",
            "Strength",
            "Instant health",
            "Instant damage",
            "Jump boost",
            "Nausea",
            "Regeneration",
            "Resistance",
            "Fire resistance",
            "Water breathing",
            "Invisibility",
            "Blindness",
            "Night vision",
            "Hunger",
            "Weakness",
            "Poison",
            "Wither",
            "Health boost",
            "Absorption",
            "Saturation",
            "Glowing",
            "Levitation",
            "Luck",
            "Bad luck",
            "Slow falling",
            "Conduit power"});
            this.potionEffectText.Location = new System.Drawing.Point(104, 15);
            this.potionEffectText.Margin = new System.Windows.Forms.Padding(4);
            this.potionEffectText.Name = "potionEffectText";
            this.potionEffectText.Size = new System.Drawing.Size(150, 24);
            this.potionEffectText.TabIndex = 2;
            // 
            // enchantmentBox
            // 
            this.enchantmentBox.Controls.Add(this.label8);
            this.enchantmentBox.Controls.Add(this.enchantmentLevel);
            this.enchantmentBox.Controls.Add(this.addEnchantment);
            this.enchantmentBox.Controls.Add(this.enchantmentList);
            this.enchantmentBox.Controls.Add(this.label9);
            this.enchantmentBox.Controls.Add(this.enchantmentText);
            this.enchantmentBox.Enabled = false;
            this.enchantmentBox.ForeColor = System.Drawing.Color.White;
            this.enchantmentBox.Location = new System.Drawing.Point(336, 164);
            this.enchantmentBox.Name = "enchantmentBox";
            this.enchantmentBox.Size = new System.Drawing.Size(465, 110);
            this.enchantmentBox.TabIndex = 15;
            this.enchantmentBox.TabStop = false;
            this.enchantmentBox.Text = "Enchantment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Level :";
            // 
            // enchantmentLevel
            // 
            this.enchantmentLevel.Location = new System.Drawing.Point(104, 46);
            this.enchantmentLevel.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.enchantmentLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enchantmentLevel.Name = "enchantmentLevel";
            this.enchantmentLevel.Size = new System.Drawing.Size(150, 22);
            this.enchantmentLevel.TabIndex = 8;
            this.enchantmentLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addEnchantment
            // 
            this.addEnchantment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEnchantment.Location = new System.Drawing.Point(9, 74);
            this.addEnchantment.Name = "addEnchantment";
            this.addEnchantment.Size = new System.Drawing.Size(245, 30);
            this.addEnchantment.TabIndex = 4;
            this.addEnchantment.Text = "Add";
            this.addEnchantment.UseVisualStyleBackColor = true;
            this.addEnchantment.Click += new System.EventHandler(this.addEnchantment_Click);
            // 
            // enchantmentList
            // 
            this.enchantmentList.CheckBoxes = true;
            this.enchantmentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEnchantment,
            this.columnEnchantmentLevel});
            this.enchantmentList.HideSelection = false;
            this.enchantmentList.Location = new System.Drawing.Point(260, 15);
            this.enchantmentList.Name = "enchantmentList";
            this.enchantmentList.Size = new System.Drawing.Size(200, 89);
            this.enchantmentList.TabIndex = 0;
            this.enchantmentList.UseCompatibleStateImageBehavior = false;
            // 
            // columnEnchantment
            // 
            this.columnEnchantment.Text = "Enchantment";
            this.columnEnchantment.Width = 125;
            // 
            // columnEnchantmentLevel
            // 
            this.columnEnchantmentLevel.Text = "Level";
            this.columnEnchantmentLevel.Width = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(7, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Enchantment :";
            // 
            // enchantmentText
            // 
            this.enchantmentText.AutoCompleteCustomSource.AddRange(new string[] {
            "Protection",
            "Fire protection",
            "Blast protection",
            "Projectile protection",
            "Respiration",
            "Aqua affinity",
            "Thorns",
            "Depth strider",
            "Frost walker",
            "Curse of binding",
            "Sharpness",
            "Smite",
            "Bane of arthropods",
            "Knockback",
            "Fire aspect",
            "Looting",
            "Efficiency",
            "Silk touch",
            "Unbreaking",
            "Fortune",
            "Power",
            "Punch",
            "Flame",
            "Infinity",
            "Luck of the sea",
            "Lure",
            "Loayalty",
            "Impaling",
            "Riptide",
            "Channeling",
            "Mending",
            "Curse of vanishing"});
            this.enchantmentText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.enchantmentText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.enchantmentText.FormattingEnabled = true;
            this.enchantmentText.Items.AddRange(new object[] {
            "Protection",
            "Fire protection",
            "Blast protection",
            "Projectile protection",
            "Respiration",
            "Aqua affinity",
            "Thorns",
            "Depth strider",
            "Frost walker",
            "Curse of binding",
            "Sharpness",
            "Smite",
            "Bane of arthropods",
            "Knockback",
            "Fire aspect",
            "Looting",
            "Efficiency",
            "Silk touch",
            "Unbreaking",
            "Fortune",
            "Power",
            "Punch",
            "Flame",
            "Infinity",
            "Luck of the sea",
            "Lure",
            "Loayalty",
            "Impaling",
            "Riptide",
            "Channeling",
            "Mending",
            "Curse of vanishing"});
            this.enchantmentText.Location = new System.Drawing.Point(104, 15);
            this.enchantmentText.Margin = new System.Windows.Forms.Padding(4);
            this.enchantmentText.Name = "enchantmentText";
            this.enchantmentText.Size = new System.Drawing.Size(150, 24);
            this.enchantmentText.TabIndex = 2;
            // 
            // optionBox
            // 
            this.optionBox.Controls.Add(this.info);
            this.optionBox.Controls.Add(this.itemIdList);
            this.optionBox.Controls.Add(this.label1);
            this.optionBox.Controls.Add(this.creativeTab);
            this.optionBox.Controls.Add(this.itemID);
            this.optionBox.Controls.Add(this.attribute);
            this.optionBox.Controls.Add(this.label4);
            this.optionBox.Controls.Add(this.enchantment);
            this.optionBox.Controls.Add(this.unbreakable);
            this.optionBox.Controls.Add(this.itemPlace);
            this.optionBox.Controls.Add(this.label3);
            this.optionBox.Controls.Add(this.itemDamage);
            this.optionBox.Controls.Add(this.label2);
            this.optionBox.Controls.Add(this.itemNumber);
            this.optionBox.Controls.Add(this.label5);
            this.optionBox.ForeColor = System.Drawing.Color.White;
            this.optionBox.Location = new System.Drawing.Point(30, 77);
            this.optionBox.Name = "optionBox";
            this.optionBox.Size = new System.Drawing.Size(300, 197);
            this.optionBox.TabIndex = 16;
            this.optionBox.TabStop = false;
            this.optionBox.Text = "Option";
            // 
            // info
            // 
            this.info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(182, 74);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(111, 22);
            this.info.TabIndex = 14;
            this.info.Text = "Info";
            this.info.UseVisualStyleBackColor = true;
            this.info.Click += new System.EventHandler(this.info_Click);
            // 
            // itemIdList
            // 
            this.itemIdList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemIdList.Location = new System.Drawing.Point(10, 156);
            this.itemIdList.Name = "itemIdList";
            this.itemIdList.Size = new System.Drawing.Size(283, 30);
            this.itemIdList.TabIndex = 13;
            this.itemIdList.Text = "Item ID list";
            this.itemIdList.UseVisualStyleBackColor = true;
            this.itemIdList.Click += new System.EventHandler(this.itemIdList_Click);
            // 
            // attributeBox
            // 
            this.attributeBox.Controls.Add(this.label11);
            this.attributeBox.Controls.Add(this.attributeLevel);
            this.attributeBox.Controls.Add(this.addAttribute);
            this.attributeBox.Controls.Add(this.attributeList);
            this.attributeBox.Controls.Add(this.label12);
            this.attributeBox.Controls.Add(this.attributeText);
            this.attributeBox.Enabled = false;
            this.attributeBox.ForeColor = System.Drawing.Color.White;
            this.attributeBox.Location = new System.Drawing.Point(336, 280);
            this.attributeBox.Name = "attributeBox";
            this.attributeBox.Size = new System.Drawing.Size(465, 110);
            this.attributeBox.TabIndex = 17;
            this.attributeBox.TabStop = false;
            this.attributeBox.Text = "Attribute";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(7, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "Level :";
            // 
            // attributeLevel
            // 
            this.attributeLevel.DecimalPlaces = 1;
            this.attributeLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.attributeLevel.Location = new System.Drawing.Point(104, 46);
            this.attributeLevel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.attributeLevel.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.attributeLevel.Name = "attributeLevel";
            this.attributeLevel.Size = new System.Drawing.Size(150, 22);
            this.attributeLevel.TabIndex = 8;
            // 
            // addAttribute
            // 
            this.addAttribute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAttribute.Location = new System.Drawing.Point(9, 74);
            this.addAttribute.Name = "addAttribute";
            this.addAttribute.Size = new System.Drawing.Size(245, 30);
            this.addAttribute.TabIndex = 4;
            this.addAttribute.Text = "Add";
            this.addAttribute.UseVisualStyleBackColor = true;
            this.addAttribute.Click += new System.EventHandler(this.addAttribute_Click);
            // 
            // attributeList
            // 
            this.attributeList.CheckBoxes = true;
            this.attributeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAttribute,
            this.columnAttributeLevel});
            this.attributeList.HideSelection = false;
            this.attributeList.Location = new System.Drawing.Point(260, 15);
            this.attributeList.Name = "attributeList";
            this.attributeList.Size = new System.Drawing.Size(200, 89);
            this.attributeList.TabIndex = 0;
            this.attributeList.UseCompatibleStateImageBehavior = false;
            // 
            // columnAttribute
            // 
            this.columnAttribute.Text = "Attribute";
            this.columnAttribute.Width = 125;
            // 
            // columnAttributeLevel
            // 
            this.columnAttributeLevel.Text = "Level";
            this.columnAttributeLevel.Width = 50;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(7, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "Attribute :";
            // 
            // attributeText
            // 
            this.attributeText.AutoCompleteCustomSource.AddRange(new string[] {
            "Max health",
            "Follow range",
            "Knockback resistance",
            "Mouvement speed",
            "Attack damage",
            "Horse jump strength",
            "Zombie spawn reinforcements",
            "Attack speed",
            "Armor",
            "Armor toughness",
            "Luck"});
            this.attributeText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.attributeText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.attributeText.FormattingEnabled = true;
            this.attributeText.Items.AddRange(new object[] {
            "Max health",
            "Follow range",
            "Knockback resistance",
            "Mouvement speed",
            "Attack damage",
            "Horse jump strength",
            "Zombie spawn reinforcements",
            "Attack speed",
            "Armor",
            "Armor toughness",
            "Luck"});
            this.attributeText.Location = new System.Drawing.Point(104, 15);
            this.attributeText.Margin = new System.Windows.Forms.Padding(4);
            this.attributeText.Name = "attributeText";
            this.attributeText.Size = new System.Drawing.Size(150, 24);
            this.attributeText.TabIndex = 2;
            // 
            // codeText
            // 
            this.codeText.Location = new System.Drawing.Point(30, 280);
            this.codeText.Multiline = true;
            this.codeText.Name = "codeText";
            this.codeText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeText.Size = new System.Drawing.Size(300, 102);
            this.codeText.TabIndex = 18;
            // 
            // colorBox
            // 
            this.colorBox.Controls.Add(this.label16);
            this.colorBox.Controls.Add(this.htmlValue);
            this.colorBox.Controls.Add(this.label15);
            this.colorBox.Controls.Add(this.blue);
            this.colorBox.Controls.Add(this.label14);
            this.colorBox.Controls.Add(this.red);
            this.colorBox.Controls.Add(this.colorPanel);
            this.colorBox.Controls.Add(this.label13);
            this.colorBox.Controls.Add(this.green);
            this.colorBox.Enabled = false;
            this.colorBox.ForeColor = System.Drawing.Color.White;
            this.colorBox.Location = new System.Drawing.Point(336, 396);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(465, 130);
            this.colorBox.TabIndex = 19;
            this.colorBox.TabStop = false;
            this.colorBox.Text = "Color";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(7, 104);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 16);
            this.label16.TabIndex = 16;
            this.label16.Text = "HTML value :";
            // 
            // htmlValue
            // 
            this.htmlValue.Location = new System.Drawing.Point(104, 101);
            this.htmlValue.Name = "htmlValue";
            this.htmlValue.Size = new System.Drawing.Size(150, 22);
            this.htmlValue.TabIndex = 15;
            this.htmlValue.Text = "#000000";
            this.htmlValue.TextChanged += new System.EventHandler(this.htmlValue_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(7, 74);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "Blue :";
            // 
            // blue
            // 
            this.blue.Location = new System.Drawing.Point(104, 72);
            this.blue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(150, 22);
            this.blue.TabIndex = 13;
            this.blue.ValueChanged += new System.EventHandler(this.blue_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(7, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "Red :";
            // 
            // red
            // 
            this.red.Location = new System.Drawing.Point(104, 16);
            this.red.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(150, 22);
            this.red.TabIndex = 11;
            this.red.ValueChanged += new System.EventHandler(this.red_ValueChanged);
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(260, 15);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(200, 108);
            this.colorPanel.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(7, 46);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 16);
            this.label13.TabIndex = 9;
            this.label13.Text = "Green :";
            // 
            // green
            // 
            this.green.Location = new System.Drawing.Point(104, 44);
            this.green.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(150, 22);
            this.green.TabIndex = 8;
            this.green.ValueChanged += new System.EventHandler(this.green_ValueChanged);
            // 
            // make
            // 
            this.make.Enabled = false;
            this.make.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.make.Location = new System.Drawing.Point(30, 388);
            this.make.Name = "make";
            this.make.Size = new System.Drawing.Size(300, 30);
            this.make.TabIndex = 20;
            this.make.Text = "Make";
            this.make.UseVisualStyleBackColor = true;
            this.make.Click += new System.EventHandler(this.make_Click);
            // 
            // makeAndAdd
            // 
            this.makeAndAdd.Enabled = false;
            this.makeAndAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeAndAdd.Location = new System.Drawing.Point(30, 424);
            this.makeAndAdd.Name = "makeAndAdd";
            this.makeAndAdd.Size = new System.Drawing.Size(300, 30);
            this.makeAndAdd.TabIndex = 21;
            this.makeAndAdd.Text = "Make and add";
            this.makeAndAdd.UseVisualStyleBackColor = true;
            this.makeAndAdd.Click += new System.EventHandler(this.makeAndAdd_Click);
            // 
            // delete
            // 
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Location = new System.Drawing.Point(30, 496);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(300, 30);
            this.delete.TabIndex = 23;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // copy
            // 
            this.copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copy.Location = new System.Drawing.Point(30, 460);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(300, 30);
            this.copy.TabIndex = 22;
            this.copy.Text = "Copy";
            this.copy.UseVisualStyleBackColor = true;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(30, 529);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 16);
            this.label17.TabIndex = 24;
            this.label17.Text = "This software was make by";
            // 
            // channelLink
            // 
            this.channelLink.AutoSize = true;
            this.channelLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.channelLink.Location = new System.Drawing.Point(194, 529);
            this.channelLink.Name = "channelLink";
            this.channelLink.Size = new System.Drawing.Size(63, 16);
            this.channelLink.TabIndex = 25;
            this.channelLink.TabStop = true;
            this.channelLink.Text = "nt games";
            this.channelLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.channelLink_LinkClicked);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(727, 529);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 16);
            this.label18.TabIndex = 26;
            this.label18.Text = "Version 2.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 550);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.channelLink);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.copy);
            this.Controls.Add(this.makeAndAdd);
            this.Controls.Add(this.make);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.codeText);
            this.Controls.Add(this.attributeBox);
            this.Controls.Add(this.optionBox);
            this.Controls.Add(this.enchantmentBox);
            this.Controls.Add(this.potionBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "NBT Tag Code Maker";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNumber)).EndInit();
            this.potionBox.ResumeLayout(false);
            this.potionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.potionDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.potionLevel)).EndInit();
            this.enchantmentBox.ResumeLayout(false);
            this.enchantmentBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enchantmentLevel)).EndInit();
            this.optionBox.ResumeLayout(false);
            this.optionBox.PerformLayout();
            this.attributeBox.ResumeLayout(false);
            this.attributeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attributeLevel)).EndInit();
            this.colorBox.ResumeLayout(false);
            this.colorBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox creativeTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox enchantment;
        private System.Windows.Forms.CheckBox attribute;
        private System.Windows.Forms.NumericUpDown itemPlace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown itemID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown itemDamage;
        private System.Windows.Forms.CheckBox unbreakable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown itemNumber;
        private System.Windows.Forms.GroupBox potionBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox potionEffectText;
        private System.Windows.Forms.ListView potionList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown potionLevel;
        private System.Windows.Forms.Button addPotion;
        private System.Windows.Forms.GroupBox enchantmentBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown enchantmentLevel;
        private System.Windows.Forms.Button addEnchantment;
        private System.Windows.Forms.ListView enchantmentList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox enchantmentText;
        private System.Windows.Forms.GroupBox optionBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown potionDuration;
        private System.Windows.Forms.GroupBox attributeBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown attributeLevel;
        private System.Windows.Forms.Button addAttribute;
        private System.Windows.Forms.ListView attributeList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox attributeText;
        private System.Windows.Forms.TextBox codeText;
        private System.Windows.Forms.GroupBox colorBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown green;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox htmlValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown blue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown red;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button make;
        private System.Windows.Forms.Button makeAndAdd;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button copy;
        private System.Windows.Forms.ColumnHeader columnAttribute;
        private System.Windows.Forms.ColumnHeader columnAttributeLevel;
        private System.Windows.Forms.ColumnHeader columnEnchantment;
        private System.Windows.Forms.ColumnHeader columnEnchantmentLevel;
        private System.Windows.Forms.ColumnHeader columnPotionEffect;
        private System.Windows.Forms.ColumnHeader columnPotionLevel;
        private System.Windows.Forms.ColumnHeader columnPotionDuration;
        private System.Windows.Forms.Button info;
        private System.Windows.Forms.Button itemIdList;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.LinkLabel channelLink;
        private System.Windows.Forms.Label label18;
    }
}

