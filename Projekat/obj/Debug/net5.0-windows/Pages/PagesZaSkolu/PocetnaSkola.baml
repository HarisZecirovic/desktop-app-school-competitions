   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Projekat.Pages.PagesZaSkoluProjekat.Pages.PagesZaSkolu  5   	   .    (Projekat.Pages.PagesZaSkolu.PocetnaSkola   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Projekat.Pages.PagesZaSkolu     5   	   -   5          � Title$  PocetnaSkola��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5       � ColumnDefinitions 5      �� 5      �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   $��2��68   ��5      �� 5      .��5      �  � Color$ #7be9f6��6#   	 � Offset$		 0.0Q�63   � 5      $ #f083da��6#   $	 1Q�63   5      ._�5      �� -   5        
 ��Name$
 label��5      $�� ��6#   $��Right=�6.   5       �� 5!      $��1��6   $��0��6&   .+�5#      �� -   5         ��Name$ listView��5#      $	��250��6Q   $	��380��6^   ��6-   �� *
korisnici2+ �� View 5$      �� 5%      .P�5&      ��  �� Width$ 76��6S   $	��Ime��6_    �� DisplayMemberBinding 6-   �� *Ime+5(      �� 5)      $ 76��6W   $��Prezime��6c    6-   �� *	Prezime+5+      �� 5,      $ 76��6]   $��Datum Rodjenja��6i    6-   �� *DatumRodjenja+5.      �� 5/      $ 76��6V   $��Razred��6b    6-   �� *Razred+51      �� 52      $ 76��6W   $��ImeTima��6c    6-   �� *	ImeTima+54      58      5;      �� 5<      $��1��6   $��1��6*    �� Orientation$ 
Horizontal=�6:   $��0,0,0,0q�6S   $
��Left=�6d   $	��Top=�6   .+�5=      �� -   5        $	��100��5=      $��40��6+   $��PRIHVATI��67   $��
10,30,10,0q�6J   6^   �� 5>      -   5        $	��100��5>      $��40��6+   $��ODBIJ��67   $��
10,30,10,0q�6G   6[   5E      5G      �� 5H      $��1��6   $��1��6&   $ 
Horizontal=�66   $��0,0,0,0q�6O   $
��Left=�6`   $	��Top=�6{   .+�5I      �� -   5        $	��100��5I      $��40��6#   $	��TIM��6/   $��	30,0,10,0q�6=   6P   �� 5J      -   5        $	��100��5J      $��40��6#   $��PREGLED CLANOVA��6/   $��	30,0,10,0q�6I   6\   �� 5M      -   5        $
 label1��5M      $�� ��6(   $��Center=�63   5Q      �� 5R      $��1��6   $��1��6&   $ 
Horizontal=�66   $��0,60,0,0q�6O   $
��Left=�6a   $	��Top=�6|   .+�5S      �� -	   5        $	��100��5S      $��40��6'   $��
TAKMICENJE��63   $��	30,0,10,0q�6H   6[   �� 5T      -
   5        $	��100��5T      $��40��6'   $��PREGLED TAKMICENJA��63   $��	30,0,10,0q�6P   6c   5\      �� 5]      $��1��6   $��1��6&   $ 
Horizontal=�66   $��	0,120,0,0q�6O   $
��Left=�6b   $	��Top=�6}   .+�5^      �� -   5        $	��100��5^      $��40��6'   $��PODACI��63   $��	30,0,10,0q�6D   6W   �� 5_      -   5        $	��100��5_      $��40��6'   $��	ODJAVI SE��63   $��	30,0,10,0q�6G   6Z   5h      5i      5k      5l      