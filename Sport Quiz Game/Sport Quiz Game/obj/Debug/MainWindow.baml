   M S B A M L   `   `   `  ����J  FSport Quiz Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Sport_Quiz_GameSport_Quiz_Game  5   	        Sport_Quiz_Game.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Sport_Quiz_Game     5   	   $	��450��5   	   $	��800��6     � WindowStartupLocation$  CenterScreen=�6(    � Icon$ Images/sportski-kviz.jpg��5	   	    � Title$ Sportski kviz��5
   	   $	��450��6   $	��800��6,    � 	Resources 5         MyButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName��%  &	        �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��2q�5      $	 4,2q�5      
��� ���$	 6��5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � ��
 �   �6T   5      5       5"      5#      5$      .��5%      � ��5&   
   �� 5'       �� ImageSource$ Images/background.jpg��6    � RowDefinitions 5)   
   �� 5*      �� 5+      �� 5,       � ColumnDefinitions 5.   
   �� 5/      �� 50      �� 51      �� 52      .+�54   
   �� $��20q�6   $��4��6    $��Times New Roman)�64   $��Italic$�6Q   $��	UltraBold"�6d   
���**��$��60(�6�   $��Center=�6�   �� 6�   $�Dobrodošli��6�   6�   �� 55   
   $��5q�6   $��0��6   $��1��6,   $��2��6=   $��Times New Roman)�6Q   $��Italic$�6n   $��Regular"�6�   
���**��$��40(�6�   $��Bottom=�6�   $��Center=�6�   �� 56      $�Sportski kviz��6   57      �� 58   
   $��5q�6   $��1��6   $��1��6,   $��2��6=   $��Times New Roman)�6Q   $��Italic$�6n   $��Regular"�6�   
���**��$��25(�6�   $��Center=�6�   $��Center=�6�   �� 59      $�Izaberite broj pitanja: ��6   5:      �� 5;   
   -   5         ��Name$ comboBox��5;   D   $��1��6   $��1��6    $��2��60   $��2q�6V    �� SelectedIndex$ 2��6k   $��5q�5<      
���`���$��DemiBold"�62   $	��225��6H   $��Bottom=�6T   .@�5=      �� 
���`���$��DemiBold"�63   $��8��6I   �� 5>      
���`���$��DemiBold"�63   $��9��6I   �� 5?      
���`���$��DemiBold"�63   $��10��6I   �� 5@      
���`���$��DemiBold"�63   $��11��6I   �� 5A      
���`���$��DemiBold"�63   $��12��6I   �� 5B      
���`���$��DemiBold"�63   $��13��6I   �� 5C      
���`���$��DemiBold"�63   $��14��6I   �� 5D      
���`���$��DemiBold"�63   $��15��6I   5E      �� 5F   
   -   5        $��1��5F      $��2��6!   $��2��6.   
��� ���$��Times New Roman)�6V   $��20(�5G      $
��Bold"�6#   
���""��$��40��5H      $	��180��6!   $��Center=�6-   #��[  6H   $��Započnite kviz��6p    5I      ��%^   '��       �� 5J      " ��6   .�5K      ��  �@��CornerRadius$ 7��65   5L      5M      5N      5O      5P      