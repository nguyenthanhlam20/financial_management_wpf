   M S B A M L   `   `   `  ����J  FFinancialWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:FinancialWPFApp.UI.User.Views.Windows%FinancialWPFApp.UI.User.Views.Windows  5   	   B    <FinancialWPFApp.UI.User.Views.Windows.ChooseExportOptionView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:FinancialWPFApp.UI.User.Views.Windows     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	     � Title$  Choose Export Options��5	   	    � 
ResizeMode$ NoResize=�6(    � Left$	 913��5
   	   
 � Top$	 210��5   	   $	��580��5   	   $	��448��6   .��5      ��  �� Padding$ 35 10 35 35q�6      TertiaryBackgroundColor#���   6#   ._�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Hidden=�6   $	��400��6A   $	��Top=�6N   .��5      �� $ Vertical=�6   .+�5      ��   SecondaryTextColor#���  6   $��Wallet��6N   $
��Bold"�5      $��30��5        textFontSize#���  6   �� 5      -   5         ��Name$ cbWallet��5      $	��360��5      $
��Left=�6+   #���  5      $��Center=�5        ComboBoxItemStyle#��[ 5      $��40��5      �� 5       $��1��6    ���#dae2ea$��	0 20 0 10q�6@   �� 5#      #���  6   $��Transaction Type��6N   $
��Bold"�5$      $��30��5'      #���  6   �� 5)      $ 
Horizontal=�6!   .+�5*      	� -   5         	�Name$ rdIncome��5*   &   $��Income��69   
 � Tag$ 	CashMinus��6L     FilterRadioButtonStyle#��[ 5+   &   	 	� 	GroupName$	 TransactionType��5,   &   5-   '   	� 5.      -   5        $ 	rdExpense��5.   &   $��Expense��6:   $ CashPlus��6M   #���  5/      $	 TransactionType��6L   50   '   52      �� 53      $ 
Horizontal=�6!   $��0 10 0 0q�6:   .+�55      	� -   5        $ 	rdTypeAll��55   &   $��All Type��6:   $ Shape��6O   #��[ 56   &   $	 TransactionType��57   &   58   '   5:      �� 5<      $��1��6    ���#dae2ea$��	0 20 0 10q�6@   �� 5>      #���  6   $��0 0 0 10q�6N   $
��Bold"�5?      $��Transaction Status��5@      $��30��6-   #���  69   �� 5B      $ 
Horizontal=�6!   $��0 0 0 10q�6:   .+�5C      	� -   5        $ rdDraft��5C   &   $��Draft��68   $
 Book��6I   #���  5D      $	 TransactionStatus��6L   5E   '   	� 5F      -   5        $ 	rdPending��5F   &   $��Pending��6:   $ ProgressClock��6L   #��[ 5G   &   $	 TransactionStatus��5H   &   5I   '   5K      �� 5L      $ 
Horizontal=�6!   .+�5M      	� -   5        $ rdCompleted��5M   &   $��	Completed��6<   $ CheckCircle��6R   #��[ 5N   &   $	 TransactionStatus��5O   &   5P   '   	� 5Q      -   5        $ rdCancel��5Q   &   $��Cancel��69   $ Cancel��6L   #��[ 5R   &   $	 TransactionStatus��5S   &   5T   '   5U      �� 5V      $ 
Horizontal=�6!   $��0 10 0 0q�6:   .+�5X      	� -	   5        $ rdStatusAll��5X   &   $��
All Status��6<   $ Shape��6R   #��[ 5Y   &   $	 TransactionStatus��5Z   &   5[   '   5]      �� 5^      $��1��6    ���#dae2ea$��	0 20 0 10q�6@   �� 5`      #���  6   $��0 0 0 10q�6N   $
��Bold"�5a      $
��Date��5b      $��30��6   #���  6+   �� 5c      $ 
Horizontal=�6!   .+�5d      �� #���  6    $��0 5 5 5q�6R   $
��From��5e      $��30��6   #���  6+   (  "System.Windows.Controls.DatePicker  5f      -
   5        
  Name$
 dpFrom��5j   S     TertiaryWhiteColor#���  5g      
������ $��0q�5i      $	��140��5j      #���  6)   $��40��6c   $��Center=�6o   �� 5l      $��Center=�5m   /   $��To��5o      $��30��6   #���  6)     5p      -   5        $

 dpTo��5u      #���  5q      
������ $��0q�5s      $	��160��5t      #���  6)   $��35��5u   +   $��Center=�67   5v      5x      5y      �� 5z      $ 
Horizontal=�6   $��Right=�62   $��0 35 5 0q�6N   .+�5{      �� -   5         ��Name$ btnSave��5{        	AddButton#���  5~      $	��175��6=   $��0 0 10 0q�6I   .��5      �� $ 
Horizontal=�6!   .+�5�      .  (MahApps.Metro.IconPacks.PackIconMaterial  #���  60   #���  6W      Kind$ ContentSave=�6     PagingButtonIcon#���  6�   $��0 0 5 0q�6�   �� 5�      $
��Save��6    #���  6/   $
��Bold"�6Z   
�������$��Center=�6   5�      5�      �� 5�      -   5        $ 	btnCancel��5�      #���  6,   
���Gc��$	��174��5�   -   .��5�      �� $ 
Horizontal=�6!   .+�5�        #���  60   #���  5�   0   $ Close=�5�   0   #���  6=   $��0 0 5 0q�6h   �� 5�      #���  6    $��Cancel��5�       
�������$
��Bold"�5�       $��Center=�62   5�      5�      5�      5�      5�      5�      