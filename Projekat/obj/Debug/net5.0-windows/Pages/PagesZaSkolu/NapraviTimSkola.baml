   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Projekat.Pages.PagesZaSkoluProjekat.Pages.PagesZaSkolu  5   	   1    +Projekat.Pages.PagesZaSkolu.NapraviTimSkola   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Projekat.Pages.PagesZaSkolu     5   	   -   5          �Name$  Forma1��5   	    � Title$ 	TimWindow��5   	   $	��450��6   $	��380��6(    � AllowsTransparency$
 True��5	   	   
������  � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   ��5      �� 5      .��5      �  � Color$ #7be9f6��6'   	 � Offset$		 0.0Q�67   � 5      $ #f083da��6'   $	 1Q�67   5      5      �� 5      $��Center=�6   .+�5       �� $��Organizuj Tim��6   $��Light"�5!      $��	helvetica)�5"      $��22(�5#      
�������$��Center=�5%      5&      �� 5(      $��1��6   .+�5)      �� 
 �� Orientation$
 
Horizontal=�6   .+�5*      �� $��
Naziv Tima��6   
�������$
��Left=�5+      69   �� 5,      -   5         ��Name$ 	imeTimaDb��5,      $��	Helvetica)�5-      $��Light"�5.      $��20(�50      
�������
������ $��0q�53      $	��235��54      $
��Left=�55       J� Opacity$	 0.5Q�56      $��25��57      59      �� 5:      $	��250��6   $��2��5;      
�������$	 0.5Q�5=      �� 5>      $
 
Horizontal=�6   $��0,20,0,0q�67   .+�5?      �� $��Razred��6   
�������$
��Left=�6@   6]   �� 5@      -   5        $ razredDb��5A      $��	Helvetica)�5B      $��Light"�5C      $
��Left=�5D      $��20(�5E      
�������
������ $��0q�5H      $	��235��5I      $
��Left=�5J      $	 0.5Q�5K      $��25��5L      5N      �� 5O      $	��250��6   $��2��5P      
�������$	 0.5Q�5R      �� 5S      $
 
Horizontal=�6   $��0,50,0,0q�66   .+�5T      �� -   5        $	��100��5T      $��40��6+   $��POTVRDI��67   $��	85,0,10,0q�6I   6\   �� 5U      -   5        $	��100��5U      $��40��6+   $��NAZAD��67   $��0,0,10,0q�6G   6Y   5[      5\      5]      5_      5`      