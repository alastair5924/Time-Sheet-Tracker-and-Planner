   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   TImesheetTracker+   %TImesheetTracker.Views.MainWindowView   Hcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Project Time Tracker��
�������(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush �	#FF4E3757   RightWindowCommands +   %MahApps.Metro.Controls.WindowCommands  .@���   Caliburn.Micro.Message   Attach$% [Event Click] = [Action Save()]��.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSaveOutline=��� $- '[Event Click] = [Action ShowSettings()]��.��  $ Settings=�.��)  #MaterialDesignThemes.Wpf.DialogHost  .���  � ColumnDefinitions �� $��70 ��� $��* � � RowDefinitions �� $��50 ��� $��* �.+��� $��0��$��1��$��2�����	#FF5F3561�� $��1�� �� Orientation$ 
Horizontal=�$��Center=� � 	Resources 	 �� 
TargetType
 �� Property �� Value��%/   '��       �� "	 ��.��� 
 � ��
 �����.+��� $��18(�$��Start Date: ��$��Center=�(  "System.Windows.Controls.DatePicker  
�������
�������$��18(�$��Center=�$��0,0,20,0q�   SelectedDate �� *	StartDate+ �� UpdateSourceTrigger$ PropertyChanged=��� $��-��$��18(�$��Center=�$��0,0,20,0q��� $��18(�$��
End Date: ��$��Center=�  
�������
�������$��18(�$��Center=� �� *	EndDate+$ PropertyChanged=��� $��0��$��0�����	#FF402242._�  $
 Yelp=�
���� ��$
��Auto��$
��Auto��$��Stretch=�$��Stretch=��� $��1�����	#FF402242._��� $ Vertical=�  �� Triggers P� Property P� Value��%�   '��       �� "	 ��.��� 
 � ��
 ���� �� 
 � ��
 ���� �� 
 � ��$ 60���� 
 � ��$ 60�� P�  �@J�IsMouseOver . . ��� 
 � ��
 ����.+��� $, &[Event Click] = [Action ViewPlanner()]��
�������.��  $ Calendar=�$��30��$��30���� $+ %[Event Click] = [Action ViewReport()]��
�������.��  $ ClipboardOutline=�$��30��$��30���� $��1��$��1��  Caliburn.Micro.View   Model �� *CurrentPage+