   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    TImesheetTracker+   %TImesheetTracker.Views.MainWindowView   5   	   Hcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Project Time Tracker��5   	   
�������(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush �	#FF4E3757   RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      ��   Caliburn.Micro.Message   Attach$% [Event Click] = [Action Save()]��6   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSaveOutline=�6   5      �� 5      $- '[Event Click] = [Action ShowSettings()]��6   .��5        $ Settings=�6   5      5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost  .��5   
   �  � ColumnDefinitions 5      �� 5      $��70 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    .+�5       �� $��0��6   $��1��6"   $��2��62   ���	#FF5F35616F   �� 5"      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Center=�6B    � 	Resources 5#      	 �� 
TargetType
 �� Property �� Value��%T   '��       �� 5$      "	 ��6   .�5%      �� 
 � ��
 �����67   5&      5'      .+�5(      �� $��18(�6   $��Start Date: ��6*   $��Center=�6>   (  "System.Windows.Controls.DatePicker  5)      
�������
�������$��18(�6M   $��Center=�6�   $��0,0,20,0q�6�      SelectedDate 6[   �� *	StartDate+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5*      $��-��6   $��18(�6%   $��Center=�63   $��0,0,20,0q�6N   �� 5+      $��18(�6   $��
End Date: ��6*   $��Center=�6<     5,      
�������
�������$��18(�6L   $��Center=�6�    6Z   �� *	EndDate+$ PropertyChanged=�6�   5.      �� 5/      $��0��6   $��0��6"   ���	#FF402242._�50        $
 Yelp=�6   
���� ��$
��Auto��6>   $
��Auto��6L   $��Stretch=�6Y   $��Stretch=�6w   51      �� 52      $��1��6   ���	#FF402242._�53      �� $ Vertical=�6    54       �� Triggers P� Property P� Value��%*  '��       �� 55      "	 ��6    .�56      �� 
 � ��
 ���� 6;   �� 57      
 � ��
 ���� 6<   �� 58      
 � ��$ 60��67   �� 59      
 � ��$ 60��66    5:      P� 5;   "    �@J�IsMouseOver . . �5<   &   �� 
 � ��
 ����6C   5=   #   5?      5A      .+�5B      �� $, &[Event Click] = [Action ViewPlanner()]��6   
�������.��5C        $ Calendar=�6&   $��30��66   $��30��6B   5D      �� 5E      $+ %[Event Click] = [Action ViewReport()]��6   
�������.��5F        $ ClipboardOutline=�6&   $��30��6?   $��30��6K   5G      5H      5I      �� 5J      $��1��6   $��1��6Q     Caliburn.Micro.View   Model 6*   �� *CurrentPage+6Q   5K      5L      5M      