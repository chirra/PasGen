   M S B A M L   `   `   `  ���� L  HLocalizatorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:LocalizatorHelper;assembly=LocalizatorHelperLocalizatorHelper  
 PasGen   PasGen.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Hl:clr-namespace:LocalizatorHelper;assembly=LocalizatorHelper     -     �Name$  WindowPasGen�� � Title$ PasGen v. 2.0��$��302.132��$��432.024�� � Icon$ Images/asterisk.ico�� � 	Resources *   $LocalizatorHelper.LocalisationHelper 
  Helper��%   &	          .��� $��Stretch=�$
��Auto��$��0,0,5,5q�$��Stretch=�$
��Auto�� � ColumnDefinitions �� $
��111* ��� $	��95* �.+��� $
��Left=�$��	18,15,0,0q�$
��Wrap=�$	��Top=�$��16��$	��100������  �� Source# [   �� Path$  [MainWindowRes.Characters]��� -    ��Name$ TextBoxCharacters��$��0��$
��Left=�$��19��$��
121,12,0,0q� �� TextWrapping$
 Wrap=�$��8��$	��Top=�$��95���� $��0��$
��Left=�$	��154��$��8,38,0,0q�$	��Top=�$	��210��$��Stretch=����� # [  $ [MainWindowRes.Frequency]�.��� .+��� $
��Left=�$��	10,14,0,0q�$
��Wrap=�$	��Top=����� # [  $ [MainWindowRes.Vowels]��� $
��Left=�$��	10,44,0,0q�$
��Wrap=�$	��Top=����� # [  $  [MainWindowRes.Consonants]��� $
��Left=�$��	10,74,0,0q�$
��Wrap=�$	��Top=����� # [  $ [MainWindowRes.Numbers]��� $
��Left=�$��
10,104,0,0q�$
��Wrap=�$	��Top=����� # [  $ [MainWindowRes.Simbols]��� -   	 ��Name$	 SliderVowelsFrequency��$
��Left=�$��90,7,0,0q�$	��Top=�$��70��
 � SmallChange$
 1Q� � Value$ 2Q� �� AutoToolTipPlacement$ TopLeft=� �� TickPlacement$ TopLeft=� �� IsSnapToTickEnabled .  � Maximum$ 4Q��� -   $	 SliderConsonantsFrequency��$
��Left=�$��	90,37,0,0q�$	��Top=�$��70��$
 1Q�$ 2Q�$ TopLeft=�$ TopLeft=� . $ 4Q��� -   $	 SliderNumbersFrequency��$
��Left=�$��	90,67,0,0q�$	��Top=�$��70��$
 1Q�$ 2Q�$ TopLeft=�$ TopLeft=� . $ 4Q��� -   $	 SliderSimbolsFrequency��$
��Left=�$��	90,97,0,0q�$	��Top=�$��70��$
 1Q�$ 2Q�$ TopLeft=�$ TopLeft=� . $ 4Q��� -    ��Name$ CheckBoxPronounceable��$��0��$
��Left=�$��
10,206,0,0q�$	��Top=�$��Stretch=�$��15��$	��150������ # [  $# [MainWindowRes.Pronounceable]��� -   $ CheckBoxCaps��$��0��$
��Left=�$��122,206,0,0q�$	��Top=�$��Stretch=�$��15��$	��100������ # [  $ [MainWindowRes.CAPS]��� -	    ��Name$ ButtonSettings��  ImageSettings#��[ $��0��$
��Left=�$��198,203,0,0q�$	��Top=�$��18��$��18���� -
   $ ButtonGenerate��$��0��$
��Left=�$��	8,237,0,0q�$	��Top=�$��94��$��20������ # [  $+ %[MainWindowRes.CaptionGenerateButton]��� -   $ ButtonAllToClipboard��$��0��$
��Left=�$��122,237,0,0q�$	��Top=�$��94��$��20������ # [  $, &[MainWindowRes.CaptionClipboardButton]��� -   $ ButtonCopyToClipboard01��$��1��$
��Left=�$��	10,12,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard02��$��1��$
��Left=�$��	10,37,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard03��$��1��$
��Left=�$��	10,62,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard04��$��1��$
��Left=�$��	10,87,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard05��$��1��$
��Left=�$��
10,112,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard06��$��1��$
��Left=�$��
10,137,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard07��$��1��$
��Left=�$��
10,162,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard08��$��1��$
��Left=�$��
10,187,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard09��$��1��$
��Left=�$��
10,212,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]��� -   $ ButtonCopyToClipboard10��$��1��$
��Left=�$��
10,237,0,0q�$	��Top=�$	��173��$��20������ # [  $+ %[MainWindowRes.CaptionPasswordButton]�