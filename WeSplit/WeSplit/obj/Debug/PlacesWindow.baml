   M S B A M L   `   `   `  ����B  >WeSplit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WeSplitWeSplit  5   	       WeSplit.PlacesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:WeSplit  5   	   -   5          � Title$  PlacesWindow��5	   	   $	��650��6   $
��1000��6+    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]    � Icon 5      �� 5   
    �� 	UriSource$ Icon/place.png?�6    �� BitmapScalingMode$ HighQuality=�61   6a   ��5      �� 5   
    �� ImageSource$  Data/Images/background.png��6   $ HighQuality=�6?   .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $	��420 �6   �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��410 �6$   �� 5      $
��0.8* �6#   �� 5      $��0.75* �6#   �� 5      $
��1.3* �6#   �� 5       $
��0.9* �6#   �� 5!      $��0.75* �6#   .+�5$      � $��0��6   .+�5%      �� -   5        $��WeSplit��5%      $��Center=�6+   $��25(�6F   $
��Bold"�6T   
�������$��30 0 0 0q�6y   6�   5&      � 5(      $��1��6   .+�5)      �� $��Địa danh��6   $��Center=�6,   $��Center=�6G   $��18(�6d   $
��Bold"�6r   ���#2335636�   5*      � 5,      $��2��6   .+�5-      �� $��Lịch sử��6   $��Center=�6+   $��Center=�6F   $��18(�6c   $
��Bold"�6q   ���#2335636�   5.      � 50      $��3��6   .+�51      �� $��Thêm chuyến đi��6   $��Center=�62   $��Center=�6M   $��18(�6j   $
��Bold"�6x   ���#2335636�   52      � 54      $��4��6   .+�55      �� $��
Thông tin��6   $��Center=�6-   $��Center=�6H   $��18(�6e   $
��Bold"�6s   ���#2335636�   56      � 58      $��5��6   .+�59      �� $��Cài đặt��6   $��Center=�6+   $��Center=�6F   $��18(�6c   $
��Bold"�6q   ���#2335636�   5:      5<      � 5>   
   $��1��6   .+�5?      �� -   5        	 ��Name$	 	placedata��5?      $	��920��6*   $	��400��66   ��6D   �� *id+
 �� View
 5@      �� 5A      .P�5B      ��  �� Width$	 200��6)   $��Tên địa danh��65    �� CellTemplate 5C      �� 5D   "   .R�5E   &   �� $��14(�60   ��6?   �� *name+6W   5F   #   5H      �� 5J      $	 300��6)   $��Địa chỉ��65    5K      �� 5L   "   .R�5M   &   �� $��14(�60   ��6>   �� *	address+6Y   5N   #   5P      �� 5R      $	 400��6)   $��Mô tả��65    5S      �� 5T   "   .R�5U   &   �� .��5V   *   �� $��14(�64   $
��Wrap=�6`    �� TextAlignment$ Justify=�6t   ��6C   �� *discription+6�   5W   '   5X   #   5Z      5_      ��5b      �� 5c       �� 
TargetType" ��6      MaterialDesignGridViewItem �� BasedOn# [  66   .�5d      -   5        5e      5g      5i      � 5j   
   $��2��6   .+�5k      �� .+�5l      �� -   5        $��Notif��5l      $ Center=�6)   6B   �� 5m      -   5        $��
placedata1��5m      $	��900��6/    �� Orientation$ 
Horizontal=�6;   $	��Top=�6T   .+�5n      �� -   5        $��	namePlace��5n      $��3,0,3,0q�6/   $	��200��6@   $��20,0,0,0q�6L   $
��Bold"�6_   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên địa danh��6q    % !MaterialDesignFloatingHintTextBox#��[ 6�   $��Center=�6�   �� 5o      -   5        $��	addrPlace��5o      $��3,0,3,0q�6/   $	��300��6@   $��15,0,0,0q�6L   $
��Bold"�6_   $ Địa chỉ��6q   #��[ 6�   $��Center=�6�   �� 5p      -	   5        $��
descrPlace��5p      $��3,0,3,0q�60   $	��400��6A   $��15,0,0,0q�6M   $
��Bold"�6`   $ Mô tả��6r   #��[ 6�   $��Center=�6�   5q      �� 5r      -
   5        $��addPlace��5r      $��5q�6)    & "MaterialDesignFloatingActionButton#��[ 64    � ToolTip$( "MaterialDesignFloatingActionButton��6p   $��40��6�   $��40��6�   .��5s      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=�6.   $��24��6:   $��24��6F   5t      5u      5v      5x      5y      