   M S B A M L   `   `   `  ����J  FSport Quiz Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Sport_Quiz_GameSport_Quiz_Game  5   	        Sport_Quiz_Game.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Sport_Quiz_Game     5   	   -   5        $	��450��5   	   $	��900��6     � WindowStartupLocation$  CenterScreen=�6(    � Icon$ Images/sportski-kviz.jpg��5	   	    � Title$ Sportski kviz��5
   	   $	��450��6   $	��800��6,    � 	Resources 5         MyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName��%  &	        �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��4q�5      $	 4,2q�5      
��� ���$	 3��5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � ��
 �   �6T   5      5      5!      5"      5#      .��5$      � ��5%   
   �� 5&       �� ImageSource$ Images/background.jpg��6    � RowDefinitions 5(   
   �� 5)      �� 5*      �� 5+      �� 5,       � ColumnDefinitions 5.   
   �� 5/      �� 50      �� 51      �� 52      .+�54   
   �� -   5         ��Name$ resultState��54      $��0��6)   $��0��66   $��10q�6F   $��20(�6R   $��Rezultat: 0/0��6`   $��Heavy"�6u   55      �� 56   
   -   5         ��Name$
 btn1��56      $��0��6    $��3��60   $��2��6=   $��Times New Roman)�6Q   $��20(�57      $
��Bold"�6#   
���""��$��45��58      $	��400��6!   $��	Odgovor 3��6-   #��[  6A   
��� ���$��Stretch=�6|   $��Bottom=�6�   $��5q�6�   �� 59   
   -   5        $
 btn2��59      $��0��6   $��3��6/   $��2��6<   
��� ���$��Times New Roman)�6d   $��20(�5:      $
��Bold"�6#   
���""��$��45��5;      $	��400��6!   $	��Top=�6-   $��	Odgovor 1��6E   #��[  6Y   $��5,4.8,5.2,0q�6�   5<      �� 5=   
   -   5        $
 btn3��5=      $��2��6   $��3��6/   $��2��6<   
��� ���$��Times New Roman)�6d   $��20(�5>      $
��Bold"�6#   
���""��$��45��5?      $	��400��6!   $��Bottom=�6-   $��Stretch=�6H   $��	Odgovor 4��6g   #��[  6{   5@      �� 5A   
   -   5        $
 btn4��5A      $��2��6   $��3��6/   $��2��6<   
��� ���$��Times New Roman)�6d   $��20(�5B      $
��Bold"�6#   
���""��$��45��5C      $	��400��6!   $	��Top=�6-   $��Stretch=�6E   $��	Odgovor 2��6c   #��[  6w   5D      �� 5E   
   -   5         ��Name$ picture��5E      $��5q�6!   $
��Fill=�6,   $��0��6;   $��2��6H   $��1��6Y   $��2��6i   $��Images/sportski-kviz.jpg��6}   �� 5F   
   -   5        $ questionNumber��5F      $��2��6,   $��1��69   $��2��6I   $��1. pitanje: ��6]   $��Center=�6q   $��
ExtraBlack"�6�   $��20(�6�   �� 5G   
   -	   5        $ questionText��5G      $��2��6*   $��0��67   $��4��6G   $��Ovo je neko pitanje.... ��6[   $��Center=�6{   $��Center=�6�   $
��Bold"�6�   $��20(�6�   5H      5I      