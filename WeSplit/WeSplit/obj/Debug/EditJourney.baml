   M S B A M L   `   `   `  ����B  >WeSplit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WeSplitWeSplit  5   	       WeSplit.EditJourney   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:WeSplit  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ New Journey��5   	   $	��650��6   $
��1000��6*    � WindowStartupLocation$ CenterScreen=�6g    � 
ResizeMode$ NoResize=�6�    � Icon 5      �� 5   
    �� 	UriSource$ Icon/update.png?�6    �� BitmapScalingMode$ HighQuality=�62   6b   ��5      �� 5   
    �� ImageSource$  Data/Images/background.png��6   $ HighQuality=�6@   .��5      � .+�5   
   �� $��LET 'S GO ON A NEW TRIP��6     MaterialDesignCardGroupBox#���  64   $��31.6,43q�6i   	 � UseLayoutRounding	 .  ��5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6!   $��Center=�6:   $��Center=�6W   .+�5      ��  $  MaterialDesignSubtitle1TextBlock#��[ 6$   $
��Bold"�6o   $��25(�6�   ��6^   �� 6�   5      5      .��5       �  � ColumnDefinitions 5!      �� 5"      $��1* �6'   �� 5#      $��1* �6'    � RowDefinitions 5%      �� 5&      6&   �� 5'      6&   .+�5)      �� $��0��6   $��0��6.   $��10q�6;   .+�5*      �� -   5        $��journeyName��5*      $��0,0,0,20q�62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên Chuyến Đi��6D    % !MaterialDesignFloatingHintTextBox#��[ 6s   
���   �$��Center=�6�   $��20(�6�   �� 5,      -   5        $��journeyPlace��5,      $��0,0,0,20q�63   $ Địa Danh��6E   
���   � �� 
IsEditable .  $��20(�6�   ��6�   �� *	_places+��5-      �� 5.      .R�5/   "   �� $
 
Horizontal=�6-   .+�50   &   �� ��60   �� *id+6G   �� 51   &   $	�� - ��60   6>   �� 52   &   ��60   �� *name+6I   53   #   54      56      �� 57      $
 
Horizontal=�6!   $��Center=�6:   .+�58      (  "System.Windows.Controls.DatePicker  -   5        $��journeyBegDate��58   %   $��0,0,10,0q�6;   $
��Left=�6M   $
��auto��6h   $ 	Ngày Đi��6u    $  MaterialDesignOutlinedDatePicker#��[ 6�   $��20(�6�   6�     59      -   5        $��journeyEndDate��59   %   $��	10,0,0,00q�6;   $
��Left=�6N   $
��auto��6i   $ 
Ngày Về��6v   #��[ 6�   $��20(�6�   5:      5<      �� 5=      $��1��6   $��0��6.   $��10q�6;   .+�5>      �� -   5        $��routeNameEdit��5>   2   $��0,15,0,0q�6    $ Nơi Dừng Chân��6G   
���   �$��Center=�6�   $��20(�6�    .  $y�Visible=�6  ��6v   �� *	_routes+��5?      �� 5@      .R�5A   "   �� $
 
Horizontal=�6-   .+�5B   &   �� ��60   �� *id+6G   �� 5C   &   $	�� - ��60   6>   �� 5D   &   ��60   �� *place+6J   5E   #   5F      5H      �� 5I      -   5        $��routeNameAddNew��5I      $ Nơi Dừng Chân��65   #��[ 6d   
���   �$��Center=�6�   $��20(�6�   $y�	Collapsed=�6�   �� 5L      $
 
Horizontal=�6!   $��0,0,0,0q�6:   .+�5N      �� -   5        $��
routeMoney��5N   "   $��0,0,20,0q�64   $	��200��6F   $
��Left=�6R   $ Chi phí��6m   #��[ 6�   
���   �$��Center=�6�   $��20(�6�   6  �� 5P      -	   5        $��	saveRoute��5P   !   $��20,0,0,0q�62   $��50��6E   $��40��6P    � ToolTip$ 
Save Route��6�   ��6\   0  *MaterialDesignThemes.Wpf.PackIconExtension  *ContentSave+6�   �� 5Q      -
   5        $��addRouteAddNew��5Q   !   $��20,0,0,0q�67   $��50��6J   $��40��6U   $ 	Add Route��6�   ��6a     *	MapPlus+6�   �� 5R      -   5        $��addRouteEdit��5R   !   $��20,0,0,0q�65   $��50��6H   $��40��6S   $ 
Edit Route��6�   $y�	Collapsed=�6�   ��6_     *ContentSaveEdit+6�   �� 5S      -   5        $��finishEditJourney��5S   !   $��20,0,0,0q�6:   $��50��6M   $��40��6X   $ Finish Edit Journey��6�   ��6d     *	ExitToApp+6�   5T      �� 5U      -   5        $	��Err��5U   +   $��5q�6    
���  ��6I   5V      �� 5W      $��1��6   $��0��6*   $��Center=�6:   $��Center=�6W   .+�5X      �� -   5        $��journeyThumbnail��5X      $	��200��64   $	��250��6A   $y�Visible=�6M   6e   �� 5Y      -   5        $��addThumbail��5Y      .��6J   Add Picture6W   5Z      �� 5[      -   5        $��	routeList��5[      $��1��6L   $��1��6Y   $��Center=�6i   ��6,   �� *	_routes+ �� View 5\      �� 5]      .P�5^      �� $��Nơi Dừng Chân��6T    �� DisplayMemberBinding 6-   �� *place+6T   �� 5_      $��Chi Phí��6S    6-   �� *cost+6S   5`      ��5c      �� 5d       �� 
TargetType" ��6      MaterialDesignGridViewItem �� BasedOn# [ 6C   5f      5h      5i      5j      5k      5m      