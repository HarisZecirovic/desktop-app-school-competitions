   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Projekat.Pages.PocetnaProjekat.Pages.Pocetna  5   	   0    *Projekat.Pages.Pocetna.OrganizujTakmicenje   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Projekat.Pages.Pocetna     5   	     � Title$  OrganizujTakmicenje��5   	   $	��450��6%   $	��400��62    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��75 �6    �� 5       � ColumnDefinitions 5      �� 5      �� 5      $	��300 �6#   �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   $��3��68   ��5      �� 5      .��5      �  � Color$ #7be9f6��6'   	 � Offset$		 0.0Q�67   � 5      $ #f083da��6'   $	 1Q�67   5      5      �� 5       $��Center=�6   $��3��64   .+�5"      �� $��Organizuj Takmicenje��6   $��Light"�5#      $��	helvetica)�5$      $��22(�5%      
�������$��Center=�5'      5(      �� 5)      $��1��6   $��1��6&   .+�5*      �� 
 �� Orientation$
 
Horizontal=�6   .+�5+      �� $��25,0,0,0q�6   $��Naziv��6.   
�������6S   �� 5,      -   5         ��Name$ nazivDb��5,      $��	Helvetica)�5-      $��Light"�5.      $��20(�50      $��Center=�51      
�������
������ $��0q�54      $	��235��55      $
��Left=�56       J� Opacity$	 0.5Q�57      $��25��58      $��15,0,0,0q�59      5;      �� 5<      $	��250��6   $��2��5=      
�������$	 0.5Q�5?      �� 5@      $
 
Horizontal=�6   $��0,20,0,0q�67   .+�5A      �� $��25,0,0,0q�6   $��Razred��6.   
�������6T   �� 5B      -   5        $ razredDb��5C      $��	Helvetica)�5D      $��Light"�5E      $��20(�5G      $��Center=�5H      
�������
������ $��0q�5K      $	��235��5L      $
��Left=�5M      $	 0.5Q�5N      $��25��5O      $��15,0,0,0q�5P      5R      �� 5S      $	��250��6   $��2��5T      
�������$	 0.5Q�5V      �� 5W      $
 
Horizontal=�6   $��0,20,0,0q�67   .+�5X      �� $��25,0,0,0q�6   $	��Rok��6.   
�������6Q   (  "System.Windows.Controls.DatePicker  5Y      -   5          Name$ rokZaPrijavuDb��5Y   !   5Z      �� 5[      $	��250��6   $��2��5\      
�������$	 0.5Q�5^      �� 5_      $
 
Horizontal=�6   $��0,20,0,0q�67   .+�5`      �� $��25,0,0,0q�6   $��Datum��6.   
�������6S     5a      -   5        $ datumDb��5a   !   5b      �� 5c      $	��250��6   $��2��5d      
�������$	 0.5Q�5f      �� 5g      $
 
Horizontal=�6   $��Center=�66   $��0,50,0,0q�6S   .+�5h      �� -   5        $	��100��5h      $��40��6+   $��POTVRDI��67   6I   �� 5i      -   5        $	��100��5i      $��40��6+   $��NAZAD��67   $��20,0,0,0q�6G   6Y   5o      5q      5r      5t      5u      