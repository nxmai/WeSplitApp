   M S B A M L   `   `   `  ����B  >WeSplit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WeSplitWeSplit  5   	       WeSplit.EditMember   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:WeSplit  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ New Journey��5   	   $	��650��6   $
��1000��6*    � WindowStartupLocation$ CenterScreen=�6g    � 
ResizeMode$ NoResize=�6�    � Icon 5      �� 5   
    �� 	UriSource$ Icon/update.png?�6    �� BitmapScalingMode$ HighQuality=�62   6b   ��5      �� 5   
    �� ImageSource$  Data/Images/background.png��6   $ HighQuality=�6@   .��5      � .+�5   
   �� $��LET 'S GO ON A NEW TRIP��6     MaterialDesignCardGroupBox#���  64   $��31.6,43q�6i   	 � UseLayoutRounding	 .  ��5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6!   $��Center=�6:   $��Center=�6W   .+�5      ��  $  MaterialDesignSubtitle1TextBlock#��[ 6$   $
��Bold"�6o   $��25(�6�   ��6^   �� 6�   5      5      .��5!      �  � ColumnDefinitions 5"      �� 5#      $��1* �6'   �� 5$      $��1* �6'    � RowDefinitions 5&      �� 5'      6&   �� 5(      6&   .+�5*      �� $��0��6   $��0��6.   $��10q�6;   .+�5+      �� -   5        $��journeyName��5+      $��0,0,0,20q�62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên Chuyến Đi��6D    % !MaterialDesignFloatingHintTextBox#��[ 6s   
�������$��Center=�6�   $��20(�6�   �� 5-      -   5        $��journeyPlace��5-      $��0,0,0,20q�63   $ Địa Danh��6E   
������� �� 
IsEditable .  $��20(�6�   ��6�   �� *	_places+��5.      �� 5/      .R�50   "   �� $
 
Horizontal=�6-   .+�51   &   �� ��60   �� *id+6G   �� 52   &   $	�� - ��60   6>   �� 53   &   ��60   �� *name+6I   54   #   55      57      �� 58      $
 
Horizontal=�6!   $��Center=�6:   .+�59      (  "System.Windows.Controls.DatePicker  -   5        $��journeyBegDate��59   %   $��0,0,10,0q�6;   $
��Left=�6M   $
��auto��6h   $ 	Ngày Đi��6u    $  MaterialDesignOutlinedDatePicker#��[ 6�   $��20(�6�   {�.  6    5:      -   5        $��journeyEndDate��5:   %   $��10,0,0,0q�6;   $
��Left=�6M   $
��auto��6h   $ 
Ngày Về��6u   #��[ 6�   $��20(�6�   {�.  6�   5;      5=      �� 5>      $��1��6   $��0��6.   $��10q�6;   .+�5?      �� -   5        $��memberNameEdit��5?   2   $��0,15,0,0q�6    $ Tên thành viên��6H   
���   �$��Center=�6�   $��20(�6�    .  $y�Visible=�6  ��6x   �� *	_routes+��5@      �� 5A      .R�5B   "   �� $
 
Horizontal=�6-   .+�5C   &   �� ��60   �� *id+6G   �� 5D   &   $	�� - ��60   6>   �� 5E   &   ��60   �� *name+6I   5F   #   5G      5I      �� 5J      -   5        $��memberNameAddNew��5J      $ Tên thành viên��66   #��[ 6f   
���   �$��Center=�6�   $��20(�6�   $y�	Collapsed=�6�   �� 5M      .+�5N      �� -   5        $��memberPhone��5N   "   $��0,0,20,0q�65   $	��200��6G   $
��Left=�6S   $ Số điện thoại ��6n   #��[ 6�   
���   �$��Center=�6�   $��20(�6  6  �� 5O      $
 
Horizontal=�6%   $��0,0,0,0q�6>   .+�5Q      �� -	   5        $��memberMoney��5Q   &   $��0,0,20,0q�69   $	��200��6K   $
��Left=�6W   $ 
Tiền Thu��6r   #��[ 6�   
���   �$��Center=�6�   $��20(�6  6  �� 5S      -
   5        $��
saveMember��5S   %   $��20,0,0,0q�67   $��50��6J   $��40��6U    � ToolTip$ Save Member��6�   ��6a   0  *MaterialDesignThemes.Wpf.PackIconExtension  *ContentSave+6�   �� 5T      -   5        $��addMemberAddNew��5T   %   $��20,0,0,0q�6<   $��50��6O   $��40��6Z   $ 
Add Member��6�   ��6f     *	MapPlus+6�   �� 5U      -   5        $��addMemberEdit��5U   %   $��20,0,0,0q�6:   $��50��6M   $��40��6X   $ Edit Member��6�   $y�	Collapsed=�6�   ��6d     *ContentSaveEdit+6�   �� 5V      -   5        $��finishEditJourney��5V   %   $��20,0,0,0q�6>   $��50��6Q   $��40��6\   $ Finish Edit Member��6�   ��6h     *	ExitToApp+6�   5W      5X      �� 5Y      -   5        $	��Err��5Y   +   $��5q�6    
���  ��6I   5Z      �� 5[      $��1��6   $��0��6*   $��Center=�6:   $��Center=�6W   .+�5\      �� -   5        $��journeyThumbnail��5\      $	��200��64   $	��250��6A   $y�Visible=�6M   6e   �� 5]      -   5        $��addThumbail��5]      {�.  .��6\   Add Picture6i   5^      �� 5_      -   5        $��
memberList��5_      $��1��6M   $��1��6Z   $��Center=�6j   ��6-   �� *	_routes+ �� View 5`      �� 5a      .P�5b      �� $��Tên thành viên��6S    �� DisplayMemberBinding 6-   �� *name+6S   �� 5c      $	��SDT��6Z    6-   �� *phonenumber+6Z   �� 5d      $��
Tiền thu��6]    6-   �� *collectedmoney+6]   5e      ��5h      �� 5i       �� 
TargetType" ��6      MaterialDesignGridViewItem �� BasedOn# [ 6C   5k      5m      5n      5o      5p      5r      