   M S B A M L   `   `   `  ����  TImesheetTracker,    &TImesheetTracker.Views.SaveContextView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��800��5      ���	#FF2C112A.��5   
   �� $��30q�6   .+�5   
   �� $��Center=�6     �� Orientation$  
Horizontal=�62   .+�5      �� $��16(�6   $��Bottom=�6&   $��Save Data and Reports��6A   
�������$
��10,0q�6u   '  !MaterialDesignThemes.Wpf.PackIcon  5	      $
��0,-2q�6&   $��Bottom=�64   $��20��6O   $��20��6[   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSaveOutline=�6f   
�������6�   5
      �� 5   
   $��10q�6   �� 5   
   -   5         ��Name$ 	dataCheck��5      $��Create Data File?��6G   $��5q�6c   
������� d� 	IsChecked 6&   �� *
DataToSave+6n   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Name of data file...��6   $��5q�6�   
���������6L   �� *DataLocation+ �� UpdateSourceTrigger$ PropertyChanged=�{�5      ��  �� ElementName$ 	dataCheck�� �� Path$ 	IsChecked�.��6e   5      �� 5      -   5        $ reportCheck��5      $��Create Report?��6P   $��5q�6i   
������� 6-   �� *ReportToSave+6t   �� 5      $ Name of report file...��6   $��5q�6�   
���������6N   �� *ReportLocation+$ PropertyChanged=�{�5      �� $ reportCheck��$ 	IsChecked�6P   �� 5      $��16(�6   
�������$��	0,15,0,10q�6:   $��Bottom=�6M   $��1��6h   $��1��6u   )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 5   '   $��OK��6i   ��6   Z� 6i   5      5      