   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Projekat.Pages.PagesZaSkoluProjekat.Pages.PagesZaSkolu  5   	   0    *Projekat.Pages.PagesZaSkolu.PromeniLozinku   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Projekat.Pages.PagesZaSkolu     5   	     � Title$  PromeniLozinku��5   	   $	��480��6    $	��380��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $	��200 �6    �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   ��5      �� 5      .��5      �  � Color$ #7be9f6��6'    � Offset$	 0.0Q�67   � 5      $ #f083da��6'   $ 1Q�67   5      5      �� 5      $��Center=�6   .+�5      �� $��Promena Lozinke��6   $��Light"�5      $��	helvetica)�5      $��22(�5       
�������$��Center=�5"      5#      �� 5$      $��1��6   .+�5%      �� 	 �� Orientation$	 
Horizontal=�6   .+�5&      �� $��Stara Lozinka��6   
�������64   G� 5'      -   5        
 G�Name$
 staraLozinkaD��5'   "   $��	Helvetica)�5(      $��Light"�5)      $��20(�5+      
�������
������ $��0q�5.      $	��235��5/      $
��Left=�50       J� Opacity$	 0.5Q�51      $��25��52      55      �� 56      $	��250��6   $��2��57      
�������$	 0.5Q�59      �� 5;      $	 
Horizontal=�6   $��0,20,0,0q�67   .+�5<      �� $��Nova Lozinka��6   
�������63   G� 5=      -   5        $
 
lozinka1Db��5>      $��	Helvetica)�5?      $��Light"�5@      $��20(�5B      
�������
������ $��0q�5E      $	��235��5F      $
��Left=�5G      $	 0.5Q�5H      $��25��5I      5L      �� 5M      $	��250��6   $��2��5N      
�������$	 0.5Q�5P      �� 5Q      $	 
Horizontal=�6   $��0,20,0,0q�67   .+�5R      �� $��Ponovite Lozinku��6   
�������$	��101��6J   G� 5S      -   5        $
 
lozinka2Db��5T      $��	Helvetica)�5U      $��Light"�5V      $��20(�5X      
�������
������ $��0q�5[      $	��235��5\      $
��Left=�5]      $	 0.5Q�5^      $��25��5_      5b      �� 5c      $	��250��6   $��2��5d      
�������$	 0.5Q�5f      �� 5g      -   5         ��Name$ 	txtGreska��5g      $��Center=�6/   
���  ��6L   �� 5h      $	 
Horizontal=�6   $��0,50,0,0q�66   .+�5i      �� -   5        $	��100��5i      $��40��6+   $��POTVRDI��67   $��	80,0,10,0q�6I   6\   �� 5k      -   5        $	��100��5k      $��40��6+   $��Zavori��67   6H   5p      5q      5u      5w      5x      