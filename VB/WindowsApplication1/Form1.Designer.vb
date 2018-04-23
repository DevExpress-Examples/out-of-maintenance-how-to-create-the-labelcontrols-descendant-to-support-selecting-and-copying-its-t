Imports Microsoft.VisualBasic
Imports System
Namespace DXSample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.memoEdit1 = New DevExpress.XtraEditors.MemoEdit()
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.myLabel1 = New DXSample.MyLabel()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' memoEdit1
			' 
			Me.memoEdit1.Location = New System.Drawing.Point(23, 102)
			Me.memoEdit1.Margin = New System.Windows.Forms.Padding(4)
			Me.memoEdit1.Name = "memoEdit1"
			Me.memoEdit1.Size = New System.Drawing.Size(328, 206)
			Me.memoEdit1.TabIndex = 1
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.memoEdit1)
			Me.panelControl1.Controls.Add(Me.myLabel1)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(387, 334)
			Me.panelControl1.TabIndex = 2
			' 
			' myLabel1
			' 
			Me.myLabel1.Location = New System.Drawing.Point(23, 55)
			Me.myLabel1.Margin = New System.Windows.Forms.Padding(4)
			Me.myLabel1.Name = "myLabel1"
			Me.myLabel1.Size = New System.Drawing.Size(79, 16)
			Me.myLabel1.TabIndex = 0
			Me.myLabel1.Text = "My Label Text"
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Springtime"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(387, 334)
			Me.Controls.Add(Me.panelControl1)
			Me.Margin = New System.Windows.Forms.Padding(4)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			Me.panelControl1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private myLabel1 As MyLabel
		Private memoEdit1 As DevExpress.XtraEditors.MemoEdit
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel

	End Class
End Namespace

