   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5   	       Projekat.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekat     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	IconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   6.   -   5          � Title$  LoginWindow��5   	   $	��450��6   $	��380��6*    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   ��5      �� 5      .��5      �  � Color$ #7be9f6��6'    � Offset$	 0.0Q�67   � 5      $ #f083da��6'   $ 1Q�67   5      5      �� 5      $��Center=�6   .+�5      �� $��	/Logo.png��6   $��80��6+   �� 5      $��Prijava na Sistem��6   $��Light"�5       $��	helvetica)�5!      $��22(�5"      
�������$��Center=�5$      5%      �� 5&      $��1��6   .+�5'      �� 	 �� Orientation$	 
Horizontal=�6   .+�5(      �� -   5        
 ��Name$
 username��5(      $��	Helvetica)�5)      $��Light"�5*      $��20(�5,      $��Center=�5-      
�������
������ $��0q�50      $	��235��51      $
��Left=�52       J� Opacity$	 0.5Q�53      $��25��54      $��63,0,0,0q�55      .  (MahApps.Metro.IconPacks.PackIconMaterial  57         Kind$ Account=�61   $��Center=�58   -   $��Center=�59   -   
�������5:   -   5;      �� 5<      $	��250��6   $��2��5=      
�������$	 0.5Q�5?      �� 5A      $	 
Horizontal=�6   $��0,20,0,0q�67   .+�5B      G� -   5         G�Name$ password��5C      $��	Helvetica)�5D      $��Light"�5E      $��20(�5G      $��Center=�5H      
�������
������ $��0q�5K      $	��235��5L      $
��Left=�5M      $	 0.5Q�5N      $��25��5O      $��63,0,0,0q�5P        5R      $ FormTextboxPassword=�61   $��Center=�5S   -   $��Center=�5T   -   
�������5U   -   5V      �� 5W      $	��250��6   $��2��5X      
�������$	 0.5Q�5Z      �� 5[      -   5        $��Zaboravili ste lozinku?��5[      
����  �$��Center=�6L   6i   �� 5\      -   5         ��Name$ 	txtGreska��5\      $��Center=�6/   
���  ��6L   �� 5]      $	 
Horizontal=�6   $��0,50,0,0q�66   .+�5^      �� -   5        $	��100��5^      $��40��6+   $��	ULOGUJ SE��67   $��	30,0,10,0q�6K   6^   �� 5_      -   5        $	��100��5_      $��40��6+   $��REGISTRUJ SE��67   $��0,0,10,0q�6N   6`   �� 5`      -   5        $	��100��5`      $��40��6+   $��Zavori��67   6H   5e      5f      5k      5n      5o      