   M S B A M L   `   `   `  ����  TImesheetTracker,    &TImesheetTracker.Views.NewDaySheetView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      �� ���	#FF2E2E2E._�5      � $��20q�6     � RowDefinitions  5      �� 5	      $
��AUTO �6    �� 5
      $
��AUTO �6    �� 5      $��* �6    �� 5      $
��AUTO �6    .+�5      �� $��0��6   .+�5      �� $��Create new day sheet��6   $��Center=�68   
�������$��16(�6l   (  "System.Windows.Controls.DatePicker  5      $��16(�6   
�������
�������$��Center=�6�      SelectedDate 6[   �� *Date+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��10q�6   �� 5      $��	20,0,20,0q�6   $��16(�6-   
������� %  !MaterialDesignFloatingHintTextBox#��[  6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$2 ,Enter how much time is available to spend...��6�   ��6R   �� *TimeAvailable+$ PropertyChanged=�6�   �� 5      $��
20,10,20,0q�6   $��16(�6.   
�������#��[  6�   $" Enter how much time spent...��6�   ��6S   �� *	TimeSpent+$ PropertyChanged=�6�   �� 5      $��10q�6   5      �� 5      $��1��6   $��16(�6%   
�������$��Center=�6J   $��Tasks��6g   �� 5      $
��Auto=�6   $	��200��6>   $��2��6N   .��5      �� -   5         ��Name$ TaskList��5      
���������61   �� *Tasks+��5      �� 5      .R�5      ��   Caliburn.Micro.View   Model 6-   �� *.+5      5      5      �� 5       $��3��6   .+�5!      �� $��10q�6     Caliburn.Micro.Message   Attach$. ([Event Click] = [Action CreateNewTask()]��6%   .��5"      ��  �� Orientation$ 
Horizontal=�6!   .+�5#      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�62   $��19��6>   �� 5$      $
��Task��6$   5%      5&      �� 5'      $��3��6   �� 5(      $��3��6   $��10,10,10,-5q�6&   $* $[Event Click] = [Action CreateNew()]��6=   .��5)        $ ContentSaveOutline=�6.   $��25��6H   $��25��6T   5+      5,      5.      5/      50      