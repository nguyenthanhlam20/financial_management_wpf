   M S B A M L   `   `   `  ����J  FFinancialWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:FinancialWPFApp.UI.Admin.ViewModels.Pages)FinancialWPFApp.UI.Admin.ViewModels.Pages  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      =    7FinancialWPFApp.UI.Admin.ViewModels.Pages.DashboardPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:FinancialWPFApp.UI.Admin.ViewModels.Pages     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      @lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf   5        N� Title$  DashboardView��5      .��5      ��    SecondaryBackgroundColor#���   6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      ��  �� Padding$ 20 15 20 15q�6    �� CornerRadius$ 10��5        PrimaryBlueColor#���  5      $	��100��5      $	��370��5      $
��Left=�5      $��0 0 20 0q�5      ._�5      ]� .+�5      �� $
��Left=�6   $ 50��63   $��Center=�6E   $��40��5      $��40��5      $
��Left=�6%   ���#ebe8e8._�5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ 
HumanChild=�61   $��20��5   -   $��20��5   -   $��Center=�69   $��Center=�6W   5      �� 5      $��Right=�6!   $ Vertical=�68   $��Right=�6O   .+�5       �� $��
Total User��6    $
��Bold"�5!       J� Opacity$	 0.8Q�5"      $��Right=�6+     textFontSize#���  5#        TertiaryWhiteColor#���  5$      �� 5&      -   5         ��Name$ lbTotalUser��5)       $��4��5&       $
��Bold"�5'      $��24(�5(      $��Right=�5*       #���  5+      5,      5-      5.      �� 5/      $ 20 15 20 15q�6   $ 10��50        SecondaryGreenColor#���  51      $	��100��52      $	��370��53      $
��Left=�54      $��0 0 20 0q�55      ._�56      ]� .+�57      �� $
��Left=�6   $ 50��63   $��Center=�6E   $��40��58      $��40��59      $
��Left=�6%   ���#ebe8e8._�5:        $ Transfer=�61   $��20��5;   -   $��20��5<   -   $��Center=�69   $��Center=�6W   5>      �� 5?      $��Right=�6!   $ Vertical=�68   $��Right=�6O   .+�5@      �� $��Total Transaction��6    $
��Bold"�5A      $	 0.8Q�5B      $��Right=�6+   #���  5C      #���  5D      �� 5F      -   5        $ lbTotalTransaction��5I       $��4��5F       $
��Bold"�5G      $��24(�5H      $��Right=�5J       #���  5K      5L      5M      5N      �� 5O      $ 20 15 20 15q�6   $ 10��5P        PrimaryRedColor#���  5Q      $	��100��5R      $	��370��5S      $
��Left=�5T      $��0 0 20 0q�5U      ._�5V      ]� .+�5W      �� $
��Left=�6   $ 50��63   $��Center=�6E   $��40��5X      $��40��5Y      $
��Left=�6%   ���#ebe8e8._�5Z        $ BabyFace=�61   $��20��5[   -   $��20��5\   -   $��Center=�69   $��Center=�6W   5^      �� 5_      $��Right=�6!   $ Vertical=�68   $��Right=�6O   .+�5`      �� $��New User��6    $
��Bold"�5a      $	 0.8Q�5b      $��Right=�6+   #���  5c      #���  5d      �� 5f      -   5        $ 	lbNewUser��5i       $��4��5f       $
��Bold"�5g      $��24(�5h      $��Right=�5j       #���  5k      5l      5m      5n      5p      �� 5q   
   $��Right=�6   $ 
Horizontal=�61   $��	0 20 13 0q�6J   .+�5s      �� $
��Bold"�6     PrimaryTextColor#���  6&   #���  6V   $
��Year��6�   �� 5t      -   5         ��Name$ cbYears��5t      $��70��6(   $��Center=�63   #���  6V   6�   5u      �� 5v   
   $ 	0 15 0 20q�6   $��0 0 0 0q�6%   ._�5w      #  LiveCharts.Wpf.CartesianChart  -   5          Name$ chartHorizontal��5y   !   &   LiveCharts.Wpf.Charts.Base.Chart	   LegendLocation$		 Top=�5w   !     SecondaryTextColor#���  66   $
��Left=�5z   !   $
��1136��6<   $	��400��6I   
   AxisX
 5|        LiveCharts.Wpf.Axis     Title$ Months��6      
Foreground# �  6.      
ShowLabels$
 True��6`      Labels 6r   �� *Labels+6�      AxisY 5�        $ New User��6      MaxValue$ 10Q�60   $	��300��6>   # �  6J      LabelFormatter 6|   �� *	Formatter+6�   5�      5�      5�      5�      