   M S B A M L   `   `   `  ����   TImesheetTracker,    &TImesheetTracker.Views.SaveContextView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $	��800�����	#FF2C112A.���� $��30q�.+��� $��Center=�  �� Orientation$  
Horizontal=�.+��� $��16(�$��Bottom=�$��Save Data and Reports��
�������$
��10,0q�'  !MaterialDesignThemes.Wpf.PackIcon  $
��0,-2q�$��Bottom=�$��20��$��20���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSaveOutline=�
��������� $��10q��� -    ��Name$ 	dataCheck��$��Create Data File?��$��5q�
������� d� 	IsChecked �� *
DataToSave+�� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Name of data file...��$��5q�
����������� *DataLocation+ �� UpdateSourceTrigger$ PropertyChanged=�{���  �� ElementName$ 	dataCheck�� �� Path$ 	IsChecked�.���� -   $ reportCheck��$��Create Report?��$��5q�
������� �� *ReportToSave+�� $ Name of report file...��$��5q�
����������� *ReportLocation+$ PropertyChanged=�{��� $ reportCheck��$ 	IsChecked��� $��16(�
�������$��	0,15,0,10q�$��Bottom=�$��1��$��1��)  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z $��OK����Z� 