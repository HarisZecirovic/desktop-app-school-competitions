   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Projekat.Pages.PocetnaProjekat.Pages.Pocetna  5   	   9    3Projekat.Pages.Pocetna.PregledArhiviranihTakmicenja   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Projekat.Pages.Pocetna     5   	   -   5          � Title$"  PregledArhiviranihTakmicenja��5   	   $	��400��6.   $	��500��6;    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      �  � RowDefinitions 5   
   �� 5      $	��110 �6   �� 5      .+�5   
   ��  �� CornerRadius$ 10��6   $��2��6#   ��5      �� 5      .��5      �  � Color$ #7be9f6��6#    � Offset$	 0.0Q�63   � 5      $ #f083da��6#   $ 1Q�63   5      5      �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��0,0,0,0q�6.   $
��Left=�6?   $	��Top=�6Z   .+�5      �� -   5        $	��100��5      $��40��6#   $��NAZAD��6/   $��
10,30,10,0q�6?   6S   5%      �� 5&   
   $��0��6   $��Center=�6"   $��Center=�6?   .+�5(      �� -   5        $��textBox��5(   R   $��0,20,0,0q�6   $	��250��6(   $��Center=�64   6R   5,      �� 5-   
   $
��Left=�6   $��1��61   $��60,0,0,0q�6?   .+�5/      �� -   5        $��listView��5/      $	��250��6L   $	��380��6Y   ��6'   �� *
takmicenje+
 �� View
 50      �� 52      .P�53      ��  �� Width$ 95��6+   $��Naziv��6h    �� DisplayMemberBinding 66   �� *NazivTakmicenja+55      �� 56      $ 95��6+   $��Razred��6i    66   �� *RazredTakmicenja+58      �� 59      $ 95��6+   $��Status��6i    66   �� *StatusTakmicenja+5;      �� 5<      $ 95��6+   $��Datum��6h    66   �� *DatumTakmicenja+5>      5C      5F      5G      5H      5J      