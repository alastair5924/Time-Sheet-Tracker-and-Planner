   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GTImesheetTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TImesheetTracker.ViewsTImesheetTracker.Views 5
   	   +   %TImesheetTracker.Views.MainWindowView   5   	   Hcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   0local$clr-namespace:TImesheetTracker.Views  5
   	     � Title$  MainWindowView��5   	   
�������(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush �	#FF4E3757   RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ Settings=�6   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� ���	#FF5F35616   �� 5   
   $��1��6@     Caliburn.Micro.View   Model 6   �� *CurrentPage+6@   �� 5   
   $��1��6   $��2��6   ���	#FF5F6067._�5       �  5!      �� 5"      $��1* �6'   �� 5#      $��4* �6'   .+�5%      � $��1��6    5&      �� 5'      �� 5(      �� 5)       � 	Resources 5+       �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value��%�  '��       �� 5,      " ��6    .�5-      �� 	 � ��$
 5q�67   �� 5.      	 � ��
 �	#FF5F35616;   �� 5/      	 � ��
 �	#FF5F60676<   �� 50      	 � ��

 �����6;   �� 51      	 � ��$
 0,0,-3,0q�67   �� 52      	 � ��$
 16(�69    53      P� 54   "    �@J�IsMouseOver . . �55   &   �� 	 � ��

 �   �6C   �� 56   &   	 � ��
 �	#FF3F3F466C   57   #   59      5:      .+�5;      �� $��0��6   $��Planner��6-     Caliburn.Micro.Message   Attach$* $[Event Click] = [Action ViewPlanner]��6?   �� 5<      $��1��6   $��Reports��6-   $- '[Event Click] = [Action ViewReportFull]��6?   �� 5=      $��2��6   $��Something Else��6-   5>      5?      5@      5A      5B      