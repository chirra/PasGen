   M S B A M L   `   `   `  ����L  HLocalizatorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:LocalizatorHelper;assembly=LocalizatorHelperLocalizatorHelper  5   	   
 PasGen   PasGen.WindowSettings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   XlocalizatorHelper:clr-namespace:LocalizatorHelper;assembly=LocalizatorHelper     5   	   -   5          �Name$  WindowSettings1��5   	    � Title$ Settings��5   	   $	��196��6   $	��271��6'    � Icon$ Images/asterisk.ico��63    � 	Resources 5      *   $LocalizatorHelper.LocalisationHelper 
  Helper��%   &	          5   
   6@   5      .��5	      � $��0,0,2,0q�6    � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ ComboBoxLanguage��5      $
��Left=�6-   $��
92,122,0,0q�6H   $	��Top=�6\   $��55��6t    �� SelectedIndex$ 0��6   $��20��6�   $��10(�6�   $��2��6�   .@�5      �� $��ru-RU��6   �� 5      $��en-US��6   5      �� 5   
   -   5         ��Name$ ButtonOk��5      $��OK��6#   $
��Left=�60   $��
46,122,0,0q�6K   $	��Top=�6_   $��75��6w   $��1��6�   �� 5   
   $
��Left=�6   $��
10,124,0,0q�6/   $
��Wrap=�6C   $	��Top=�6�   ��6W   ��  �� Source# [  	 �� Path$	 [MainWindowRes.Language]�6�   �� 5   
   $��Images/asterisk.png��6   $
��Left=�6.   $��32��6I   $��	10,10,0,0q�6U   $	��Top=�6h   $��32��6�   �� 5   
   $��Stretch=�6   $��47,7,0,0q�62   $
��Wrap=�6D   $	��Top=�6�   $��2��6�   $	��204��6�   ��6X   �� # [  $	 [MainWindowRes.Caption]�6�   �� 5   
   $��Stretch=�6   $��	47,26,0,0q�62   $
��Wrap=�6E   $	��Top=�6�   $��2��6�   $	��204��6�   $��Italic$�6�   $��10(�6�   ��6Y   �� # [  $	 [MainWindowRes.Slogan]�6�   �� 5   
   $��Stretch=�6   $��	10,57,0,0q�62   $
��Wrap=�6E   $6��0PasGen v.2.0.  Copyright (C) 2015  Oleg Kashenko��6Y   $	��Top=�6�   $��2��6�   $	��228��6�   $��10(�6�   5      5      