   M S B A M L   `   `   `  ����  TImesheetTracker+    %TImesheetTracker.Views.DaySummaryView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      -   5          >�Name$  control��5      .��5	      � 
���������5
   
   �� 5       �� Triggers 5      �� 5       �� Binding 6"   �� *	IsToday+ �� Value true6>   .a�5      ��  �� Property � �� �� Value
 �� ��6<   5      5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   $��0��6,    �� CornerRadius$ 15��6<   ._�5      �� $��10q�6    � 	Resources 5      	 �� 
TargetType��%  '��       �� 5      "	 ��6   .�5      ��  � ��$ Right=�6@   �� 5       � ��$ 5,5,40,5q�63   �� 5       � ��$ 14(�65    5      �� 5       6*   �� *	IsToday+ true6F   .a�5    "   ��  � ��
 �����6I   5!      5#      5$      .+�5%      �� �� 5&      $�Date: ��6    �� 5'      �6   �� *DisplayDate+5(      �� 5)      �� 5*      $�Time Available: ��6    �� 5+      �6   �� *TimeAvailable+5,      �� 5-      �� 5.      $�Time Spent: ��6    �� 5/      �6   �� *	TimeSpent+50      51      52      �� 53   
   $��10q�6   $��1��6#   ��.  $	��150��6L   .��54      �� $��10q�6   $��1��6'   
���������68   �� *Tasks+��55      �� 56      .R�57      �� $	��330��6)   
���   �  Caliburn.Micro.View
   Model
 6H   �� *.+58      ��5:      �� 5;      .R�5<      A�  A� Columns$ 3��6&   $	��-15q�62   5=      5?      5@      5B      5C      