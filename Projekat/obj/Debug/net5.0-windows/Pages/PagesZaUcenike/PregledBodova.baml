   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Projekat.Pages.PagesZaUcenikeProjekat.Pages.PagesZaUcenike  5   	   1    +Projekat.Pages.PagesZaUcenike.PregledBodova   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Projekat.Pages.PagesZaUcenike     5   	   -   5          � Title$  PregledBodova��5   	   $	��400��6   $	��500��6,    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $	��110 �6    �� 5      .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   ��5      �� 5      .��5      �  � Color$ #7be9f6��6#    � Offset$	 0.0Q�63   � 5      $ #f083da��6#   $ 1Q�63   5      5      �� 5      	 �� Orientation$	 
Horizontal=�6   $��0,0,0,0q�62   $
��Left=�6C   $	��Top=�6^   .+�5      �� -   5        $	��100��5      $��40��6'   $��NAZAD��63   $��
10,30,10,0q�6C   6W   5&      �� 5(      $��0��6   $��Center=�6&   $��Center=�6C   .+�5)      �� -   5        $��textBox��5)   V   $��0,20,0,0q�6   $	��250��6,   $��Center=�68   6e   5-      �� 5.   
   $
��Left=�6   $��1��61   $��60,0,0,0q�6?   .+�50      �� -   5        $��listView��50      $	��250��6K   $	��380��6X   ��6'   �� *	rezultati+
 �� View
 51      �� 53      .P�54      ��  �� Width$ 95��6N   $��Mesto��6Z    �� DisplayMemberBinding 6)   �� *Id+56      �� 57      $ 95��6O   $	��Ime��6[    6*   �� *Ime+59      �� 5:      $ 95��6S   $��Prezime��6_    6*   �� *	Prezime+5<      �� 5=      $ 95��6+   $��	Br.Bodova��6_    66   �� *Bodovi+5?      5D      5G      5H      5I      5J      5K      