   M S B A M L   `   `   `  ����B  >WeSplit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WeSplitWeSplit  5   	       WeSplit.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WeSplit     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  
MainWindow��5
   	   $	��650��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � Icon 5      �� 5   
    �� 	UriSource$ Icon/home.png?�6    �� BitmapScalingMode$ HighQuality=�60   6`   ��5      �� 5   
    �� ImageSource$  Data/Images/background.png��6   $ HighQuality=�6?    � 	Resources 5      ��%    5      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      .+�5    
   � $��0��6   	 � ColumnDefinitions	 5!      �� 5"      $	��410 �6#   �� 5#      $
��0.8* �6#   �� 5$      $��0.75* �6#   �� 5%      $
��1.3* �6#   �� 5&      $
��0.9* �6#   �� 5'      $��0.75* �6#   .+�5*      � $��0��6   .+�5+      �� $��WeSplit��6   $��Center=�6+   $��25(�6F   $
��Bold"�6T   
�������$��30 0 0 0q�6y   6�   5,      � 5.      $��1��6   .+�5/      �� -   5        $��Địa danh��5/      $��Center=�6,   $��Center=�6G   $��18(�6d   $
��Bold"�6r   ���#2335636�   50      � 52      $��2��6   .+�53      �� -   5        $��Lịch sử��53      $��Center=�6+   $��Center=�6F   $��18(�6c   $
��Bold"�6q   ���#2335636�   54      � 56      $��3��6   .+�57      �� -   5        $��
addJourney��57      $��Thêm chuyến đi��6.   $��Center=�6D   $��Center=�6_   $��18(�6|   $
��Bold"�6�   ���#2335636�   58      � 5:      $��4��6   .+�5;      �� $��
Thông tin��6   $��Center=�6-   $��Center=�6H   $��18(�6e   $
��Bold"�6s   ���#2335636�   5<      � 5>      $��5��6   .+�5?      �� -   5        $��Cài đặt��5?      $��Center=�6+   $��Center=�6F   $��18(�6c   $
��Bold"�6q   ���#2335636�   5@      5B      � 5D   
   $��1��6   	 5E      �� 5F      $
��1.3* �6#   �� 5G      $��3* �6#   �� 5H      $
��1.3* �6#   .+�5K      � $��0��6   5M      � 5O      $��1��6   .+�5P      �� ���#28292e$��1q�6/   $��Center=�6C   $��Center=�6^   
 �� CornerRadius$
 10��6{   $	��480��6�   $��37��6�   ._�5Q      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5V      �� -   5        $��searchTextBox��5V   "   
�������$��27��6K   $	��465��6W   $��12(�5W      $��Center=�6(    �� TextWrapping$
 Wrap=�5X      5Y      5Z      5[      � 5]      $��2��6   .+�5^      	� -   5        $��0 0 0 0q�5^       	� 	GroupName$ choice��6/   
 � Tag$ 1��6B   .��6c   Tên địa danh6q   	� 5_      -   5        $��	110 0 0 0q�5_      $ choice��61   $ 2��6D   .��6e   Tên thành viên6u   5`      5b      � 5e   
   $��2��6   .+�5f      �� $��Data/Images/01.png��6   $	��350��60   $��540 100 0 0q�6<   $ HighQuality=�6Q   6�   �� 5h      -	   5         ��Name$ tripdata��5h      $	��520��6)   $��Center=�6Q   $��35,0,439.667,0q�6n   ��66   �� *id+ �� View 5i      �� 5j      .P�5k      �� $��Tên chuyến đi��6O    �� Width$	 200��6f    �� DisplayMemberBinding 6)   �� *name+6f   �� 5l      $��	Ngày đi��6r   $	 150��6�    6)   �� *
datetogo+ �� StringFormat$ {0:MM/dd/yyyy}��6�   �� 5m      $��
Ngày về��6t   $	 150��6�    6)   �� *
returndate+$ {0:MM/dd/yyyy}��6�   5n      ��5q      �� 5r       �� 
TargetType" ��6      MaterialDesignGridViewItem �� BasedOn# [  66   .�5s      -
   5        5t      5w      5y      5{      5}      