   M S B A M L   `   `   `  ����L  HLocalizatorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:LocalizatorHelper;assembly=LocalizatorHelperLocalizatorHelper  5   	   
 PasGen   PasGen.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Hl:clr-namespace:LocalizatorHelper;assembly=LocalizatorHelper     5   	   -   5          �Name$  WindowPasGen��5   	    � Title$ PasGen v. 2.0��5   	   $��302.132��6   $��432.024��60    � Icon$ Images/asterisk.ico��6Y    � 	Resources 5      *   $LocalizatorHelper.LocalisationHelper 
  Helper��%   &	          5   
   60   5      .��5      � $��Stretch=�6   $
��Auto��6)   $��0,0,5,5q�67   $��Stretch=�6H   $
��Auto��6d    � ColumnDefinitions 5   
   �� 5      $
��111* �6   6.   �� 5      $	��95* �6   6-   .+�5   
   �� $
��Left=�6   $��	18,15,0,0q�6/   $
��Wrap=�6B   $	��Top=�6�   $��16��6�   $	��100��6�   ��6V   ��  �� Source# [   �� Path$  [MainWindowRes.Characters]�6�   �� 5   
   -   5         ��Name$ TextBoxCharacters��5      $��0��6-   $
��Left=�6=   $��19��6X   $��
121,12,0,0q�6d    �� TextWrapping$
 Wrap=�6x   $��8��6�   $	��Top=�6�   $��95��6�   �� 5   
   $��0��6e   $
��Left=�6u   $	��154��6�   $��8,38,0,0q�6�   $	��Top=�6�   $	��210��6�   $��Stretch=�6�   ��6   �� # [  $ [MainWindowRes.Frequency]�.��5      � .+�5      �� $
��Left=�6   $��	10,14,0,0q�67   $
��Wrap=�6J   $	��Top=�6�   ��6^   �� # [  $ [MainWindowRes.Vowels]�6�   �� 5      $
��Left=�6   $��	10,44,0,0q�67   $
��Wrap=�6J   $	��Top=�6�   ��6^   �� # [  $  [MainWindowRes.Consonants]�6�   �� 5      $
��Left=�6   $��	10,74,0,0q�67   $
��Wrap=�6J   $	��Top=�6�   ��6^   �� # [  $ [MainWindowRes.Numbers]�6�   �� 5      $
��Left=�6   $��
10,104,0,0q�67   $
��Wrap=�6K   $	��Top=�6�   ��6_   �� # [  $ [MainWindowRes.Simbols]�6�   �� 5      -   5        	 ��Name$	 SliderVowelsFrequency��5      $
��Left=�68   $��90,7,0,0q�6S   $	��Top=�6e   $��70��6}   
 � SmallChange$
 1Q�6�    � Value$ 2Q�6�    �� AutoToolTipPlacement$ TopLeft=�6�    �� TickPlacement$ TopLeft=�6�    �� IsSnapToTickEnabled .  � Maximum$ 4Q�6�   �� 5      -   5        $	 SliderConsonantsFrequency��5      $
��Left=�6<   $��	90,37,0,0q�6W   $	��Top=�6j   $��70��6�   $
 1Q�6�   $ 2Q�6�   $ TopLeft=�6�   $ TopLeft=�6�    . $ 4Q�6�   �� 5       -   5        $	 SliderNumbersFrequency��5       $
��Left=�69   $��	90,67,0,0q�6T   $	��Top=�6g   $��70��6   $
 1Q�6�   $ 2Q�6�   $ TopLeft=�6�   $ TopLeft=�6�    . $ 4Q�6�   �� 5"      -   5        $	 SliderSimbolsFrequency��5"      $
��Left=�69   $��	90,97,0,0q�6T   $	��Top=�6g   $��70��6   $
 1Q�6�   $ 2Q�6�   $ TopLeft=�6�   $ TopLeft=�6�    . $ 4Q�6�   5%      5&      �� 5)   
   -   5         ��Name$ CheckBoxPronounceable��5)      $��0��6�   $
��Left=�6�   $��
10,206,0,0q�6�   $	��Top=�6�   $��Stretch=�6�   $��15��6  $	��150��6  ��62   �� # [  $# [MainWindowRes.Pronounceable]�6H  �� 5*   
   -   5        $ CheckBoxCaps��5*      $��0��6w   $
��Left=�6�   $��122,206,0,0q�6�   $	��Top=�6�   $��Stretch=�6�   $��15��6�   $	��100��6   ��6)   �� # [  $ [MainWindowRes.CAPS]�6   �� 5+   
   -	   5         ��Name$ ButtonSettings��5+        ImageSettings#��[ 6)   $��0��6R   $
��Left=�6b   $��198,203,0,0q�6}   $	��Top=�6�   $��18��6�   $��18��6�   6�   �� 5,   
   -
   5        $ ButtonGenerate��5,      $��0��6�   $
��Left=�6�   $��	8,237,0,0q�6�   $	��Top=�6�   $��94��6�   $��20��6  ��6)   �� # [  $+ %[MainWindowRes.CaptionGenerateButton]�6  �� 5-   
   -   5        $ ButtonAllToClipboard��5-      $��0��6�   $
��Left=�6�   $��122,237,0,0q�6�   $	��Top=�6�   $��94��6�   $��20��6  ��6/   �� # [  $, &[MainWindowRes.CaptionClipboardButton]�6  �� 5.   
   -   5        $ ButtonCopyToClipboard01��5.      $��1��6�   $
��Left=�6�   $��	10,12,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 5/   
   -   5        $ ButtonCopyToClipboard02��5/      $��1��6�   $
��Left=�6�   $��	10,37,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 50   
   -   5        $ ButtonCopyToClipboard03��50      $��1��6�   $
��Left=�6�   $��	10,62,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 51   
   -   5        $ ButtonCopyToClipboard04��51      $��1��6�   $
��Left=�6�   $��	10,87,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 52   
   -   5        $ ButtonCopyToClipboard05��52      $��1��6�   $
��Left=�6�   $��
10,112,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 53   
   -   5        $ ButtonCopyToClipboard06��53      $��1��6�   $
��Left=�6�   $��
10,137,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 54   
   -   5        $ ButtonCopyToClipboard07��54      $��1��6�   $
��Left=�6�   $��
10,162,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 55   
   -   5        $ ButtonCopyToClipboard08��55      $��1��6�   $
��Left=�6�   $��
10,187,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 56   
   -   5        $ ButtonCopyToClipboard09��56      $��1��6�   $
��Left=�6�   $��
10,212,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  �� 57   
   -   5        $ ButtonCopyToClipboard10��57      $��1��6�   $
��Left=�6�   $��
10,237,0,0q�6�   $	��Top=�6�   $	��173��6�   $��20��6  ��62   �� # [  $+ %[MainWindowRes.CaptionPasswordButton]�6  58      5;      