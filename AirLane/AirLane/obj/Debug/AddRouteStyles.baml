   M S B A M L   `   `   `  ����B  >AirLane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirLaneAirLane  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Button.Static.Background  �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Border  Button.Disabled.Foreground  airport_name_from �� 
TargetType �� Property �� Value �� 
TargetType ��Name ��Name �� Triggers ]� 
Conditions	 �� Property
 �� Value �� 
TargetName 	 airport_name_to 
 length_of_route  AddRoute ��Name J� SnapsToDevicePixels ��Name P� Property P� Value  AddRouteWord 
 Route2 �� Padding'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:AirLane  5      %t  &	        &	 #     &	 F     &	 g     &	 �     &	 �     &	 �     &	 �     &	     &		 �    &	
 �    &	 	    7  &	 �    &	 6    �� 5      $  	#FFDDDDDD��67   �� 5      $  	#FF707070��63   �� 5      $  #BA1111��6:   �� 5      $  	#FF3C7FB1��66   �� 5	      $  	#FFC4E5F6��68   �� 5
      $  	#FF2C628B��64   �� 5      $  	#FFADB2B5��65   �� 5      $  	#FF838383��69   �� 5      " ��6&   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      � .+�5      �� 
����������	#FF7D8683$��1q�6L   �� 5      $ PART_ContentHost��6'   $��5,0,0,0q�6A   $��Center=�6R   �� 5      $ WaterMarkLabel��61   $��2,0,0,0q�6    $7��1Название аэропорта от куда��6I   $��Center=�6n   $y�Hidden=�5      
�������$��Arial)�6'   5       5      ]� 5       5      �� 5   "   	 � ��$
  ��6<   ./�5      �� $ WaterMarkLabel��6;    � y�$ Visible=�6W   5      5!      5#      �� 5$   
    � ��$	 200��6"   �� 5%   
    � ��$ 0 20 0 0q�6#   5&      �� 5'      " ��6$   .�5(   
   ��  � �� 5)      �� 5*      " ��6"   .R�5+      � .+�5,      �� 
����������	#FF7D8683$��1q�6L   �� 5-      $ PART_ContentHost��6'   $��5,0,0,0q�6A   $��Center=�6R   �� 5.      $ WaterMarkLabel��61   $��2,0,0,0q�6    $2��,Название аэропорта куда��6I   $��Center=�6k   $y�Hidden=�5/      
�������$��Arial)�6'   50       51      ]� 52       53      �� 54   "   	 � ��$
  ��6<   ./�56      �� $ WaterMarkLabel��6;    � y�$ Visible=�6W   57      5:      5<      �� 5=   
    � ��$	 200��6"   �� 5>   
    � ��$ 0 20 0 0q�6#   5?      �� 5B      " ��6$   .�5C   
   ��  � �� 5D      �� 5E      " ��6"   .R�5F      � .+�5G      �� 
����������	#FF7D8683$��1q�6L   �� 5H      $ PART_ContentHost��6'   $��5,0,0,0q�6A   $��Center=�6R   �� 5I      $ WaterMarkLabel��61   $��2,0,0,0q�6    $��Длинна пути��6I   $��Center=�6_   $y�Hidden=�5J      
�������$��Arial)�6'   5K       5L      ]� 5M       5N      �� 5O   "   	 � ��$
  ��6<   ./�5Q      �� $ WaterMarkLabel��6;    � y�$ Visible=�6W   5R      5U      5W      �� 5X   
    � ��$	 200��6"   �� 5Y   
    � ��$ 0 20 0 0q�6#   5Z      �� 5^      " ��6   .�5_   
   ��  � �� 5`      �� 5a      " ��6"   .R�5b      �� $ border��6   #��z��6-   #��z��6Y   #��z��6�    . ._�5c      �� $ contentPresenter��6+   |�.  #��z��6W   #��z��6�   ��. # z 6�   #��z��6  5d       5e      P� 5f       �@J�IsMouseOver . . �5g      �� $ border��6;   8    � ��6O   5h      5j      5l      �� 5m   
    � �� �#FFFFFF6/   �� 5n   
    � ��$ 40��6#   �� 5o   
    � ��$	 150��6"   �� 5p   
    � ��$ 20(�6-   �� 5q   
    � �� �#092C526'   �� 5r   
    � ��$ 
0 150 0 0 q�6#   �� 5s   
    � ��$ Добавить��6$   5t      �� 5x      " ��6!   .�5y   
   ��  �@J�Opacity$ 1Q�6$   �� 5z   
    � �� �#092C526/   �� 5{   
    � ��$ 20(�6%   �� 5|   
    � ��$	 190��6"   �� 5}   
    � ��$ Center=�60   �� 5~   
    � ��$ Center=�6.   �� 5   
    � ��$% Добавить маршрут��6!   5�      �� 5�      " ��6   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    �@�OverridesDefaultStyle . 62   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $ Border��6   $ 2q�6-    . 
������  5�        5�      SelectionStates��. 5�   "     
Unselected��6.     5�   "   Selected��. 5�   &   �� .��5�   *   �� .g�5�   .     $ 0��6B   $	 Red��6N   5�   +   5�   '   5�   #     5�   "   SelectedUnfocused��. 5�   &   �� .��5�   *   �� .g�5�   .     $ 0��6B   $ Yellow��6N   5�   +   5�   '   5�   #   5�      ._�5�      �� 5�      5�      5�      5�      5�      