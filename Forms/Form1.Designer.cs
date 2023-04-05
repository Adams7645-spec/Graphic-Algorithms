namespace GraphicAlgorithms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TablePanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.CanvasPanel = new System.Windows.Forms.Panel();
            this.MenuTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AlgorithmMenuStrip = new System.Windows.Forms.MenuStrip();
            this.BezierCurveMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.BresenhamLineMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.PolygonFillingMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TablePanelMain.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.MenuTableLayoutPanel.SuspendLayout();
            this.AlgorithmMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablePanelMain
            // 
            this.TablePanelMain.ColumnCount = 2;
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TablePanelMain.Controls.Add(this.MenuPanel, 1, 0);
            this.TablePanelMain.Controls.Add(this.CanvasPanel, 0, 0);
            this.TablePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePanelMain.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TablePanelMain.Location = new System.Drawing.Point(0, 0);
            this.TablePanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.TablePanelMain.Name = "TablePanelMain";
            this.TablePanelMain.RowCount = 1;
            this.TablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TablePanelMain.Size = new System.Drawing.Size(734, 511);
            this.TablePanelMain.TabIndex = 0;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MenuPanel.BackColor = System.Drawing.Color.LightGray;
            this.MenuPanel.Controls.Add(this.MenuTableLayoutPanel);
            this.MenuPanel.Location = new System.Drawing.Point(550, 0);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(184, 511);
            this.MenuPanel.TabIndex = 0;
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CanvasPanel.Location = new System.Drawing.Point(0, 0);
            this.CanvasPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Size = new System.Drawing.Size(550, 511);
            this.CanvasPanel.TabIndex = 1;
            // 
            // MenuTableLayoutPanel
            // 
            this.MenuTableLayoutPanel.ColumnCount = 1;
            this.MenuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MenuTableLayoutPanel.Controls.Add(this.AlgorithmMenuStrip, 0, 0);
            this.MenuTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuTableLayoutPanel.Name = "MenuTableLayoutPanel";
            this.MenuTableLayoutPanel.RowCount = 2;
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MenuTableLayoutPanel.Size = new System.Drawing.Size(184, 511);
            this.MenuTableLayoutPanel.TabIndex = 0;
            // 
            // AlgorithmMenuStrip
            // 
            this.AlgorithmMenuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.AlgorithmMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BezierCurveMenuStrip,
            this.BresenhamLineMenuStrip,
            this.PolygonFillingMenuStrip});
            this.AlgorithmMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.AlgorithmMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.AlgorithmMenuStrip.Name = "AlgorithmMenuStrip";
            this.AlgorithmMenuStrip.Size = new System.Drawing.Size(184, 60);
            this.AlgorithmMenuStrip.TabIndex = 0;
            this.AlgorithmMenuStrip.Text = "Выберите алгоритм";
            // 
            // BezierCurveMenuStrip
            // 
            this.BezierCurveMenuStrip.Name = "BezierCurveMenuStrip";
            this.BezierCurveMenuStrip.Size = new System.Drawing.Size(177, 18);
            this.BezierCurveMenuStrip.Text = "Кривые Безье";
            // 
            // BresenhamLineMenuStrip
            // 
            this.BresenhamLineMenuStrip.Name = "BresenhamLineMenuStrip";
            this.BresenhamLineMenuStrip.Size = new System.Drawing.Size(177, 18);
            this.BresenhamLineMenuStrip.Text = "Алгоритм Брейзенхема";
            // 
            // PolygonFillingMenuStrip
            // 
            this.PolygonFillingMenuStrip.Name = "PolygonFillingMenuStrip";
            this.PolygonFillingMenuStrip.Size = new System.Drawing.Size(177, 18);
            this.PolygonFillingMenuStrip.Text = "Закраска с затравкой";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.TablePanelMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.AlgorithmMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(750, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphic Algorithms";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.TablePanelMain.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.MenuTableLayoutPanel.ResumeLayout(false);
            this.MenuTableLayoutPanel.PerformLayout();
            this.AlgorithmMenuStrip.ResumeLayout(false);
            this.AlgorithmMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TablePanelMain;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel CanvasPanel;
        private System.Windows.Forms.TableLayoutPanel MenuTableLayoutPanel;
        private System.Windows.Forms.MenuStrip AlgorithmMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem BezierCurveMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem BresenhamLineMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PolygonFillingMenuStrip;
    }
}

