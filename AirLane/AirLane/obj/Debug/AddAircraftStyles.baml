   M S B A M L   `   `   `  ����B  >AirLane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirLaneAirLane  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   NameAircraft  �� 
TargetType �� Property �� Value �� 
TargetType ��Name ��Name �� Triggers ]� 
Conditions �� Property	 �� Value
 �� 
TargetName  CountOfSeats 	 Speed  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border 	 Button.Disabled.Border 
 Button.Disabled.Foreground  AddAircraft ��Name J� SnapsToDevicePixels ��Name P� Property P� Value 	 Panel  AddAircrafttWord�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:AirLane  5      %L  &	        &	 �    &	 L    &	 �    &	     &	 )    &	 J    &	 m    &	 �    &		 �    &	
 �    &	 �    7  &	 �    &	 �    �� 5
      "  ��6!   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      � .+�5      �� 
����������	#FF7D8683$��1q�6L   �� 5      $ PART_ContentHost��6'   $��5,0,0,0q�6A   $��Center=�6R   �� 5      $ WaterMarkLabel��61   $��2,0,0,0q�6    $'��!Название самолета��6I   $��Center=�6e   $y�Hidden=�5      
�������$��Arial)�6'   5       5      ]� 5       5      �� 5   "    � ��$	  ��6<   ./�5      �� $
 WaterMarkLabel��6;    � y�$ Visible=�6W   5      5      5      �� 5    
    � ��$	 200��6"   �� 5!   
    � ��$ 0 50 0 0q�6#   5"      �� 5$      "  ��6!   .�5%   
   ��  � �� 5&      �� 5'      " ��6"   .R�5(      � .+�5)      �� 
����������	#FF7D8683$��1q�6L   �� 5*      $ PART_ContentHost��6'   $��5,0,0,0q�6A   $��Center=�6R   �� 5+      $ WaterMarkLabel��61   $��2,0,0,0q�6    $#��Количество мест��6I   $��Center=�6c   $y�Hidden=�5,      
�������$��Arial)�6'   5-       5.      ]� 5/       50      �� 51   "    � ��$	  ��6<   ./�53      �� $
 WaterMarkLabel��6;    � y�$ Visible=�6W   54      57      59      �� 5:   
    � ��$	 200��6"   �� 5;   
    � ��$ 0 20 0 0q�6#   5<      �� 5>      "  ��6   .�5?   
   ��  � �� 5@      �� 5A      " ��6"   .R�5B      � .+�5C      �� 
����������	#FF7D8683$��1q�6L   �� 5D      $ PART_ContentHost��6'   $��5,0,0,0q�6A   $��Center=�6R   �� 5E      $ WaterMarkLabel��61   $��2,0,0,0q�6    $��Скорость��6I   $��Center=�6\   $y�Hidden=�5F      
�������$��Arial)�6'   5G       5H      ]� 5I       5J      �� 5K   "    � ��$	  ��6<   ./�5M      �� $
 WaterMarkLabel��6;    � y�$ Visible=�6W   5N      5Q      5S      �� 5T   
    � ��$	 200��6"   �� 5U   
    � ��$ 0 20 0 0q�6#   5V      �� 5Z      $ 	#FFDDDDDD��67   �� 5[      $ 	#FF707070��63   �� 5\      $ #BA1111��6:   �� 5]      $ 	#FF3C7FB1��66   �� 5^      $ 	#FFC4E5F6��68   �� 5_      $ 	#FF2C628B��64   �� 5`      $ 	#FFADB2B5��65   �� 5a      $ 	#FF838383��69   �� 5e      "  ��6    .�5f   
   ��  � �� �#FFFFFF6/   �� 5g   
    � ��$ 40��6#   �� 5h   
    � ��$	 150��6"   �� 5i   
    � ��$ 20(�6-   �� 5j   
    � ��$ 
0 150 0 0 q�6#   �� 5k   
    � ��$ Добавить��6$   �� 5l   
    � �� �#092C526'   �� 5n   
    � �� 5o      �� 5p      " ��6"   .R�5q      �� $ border��6   #��z��6-   #��z��6Y   #��z��6�    . ._�5r      �� $ contentPresenter��6+   |�.  #��z��6W   #��z��6�   ��. # z 6�   #��z��6  5s       5t      P� 5u       �@J�IsMouseOver . . �5v      �� $
 border��6;   8    � ��6O   5w      5y      5{      5|      �� 5~      "  ��6   .�5�   
   ��  �@J�Opacity$	 0.8Q�6$   �� 5�   
    � ��
 � � �6/   �� 5�   
    � �� �#FFFFFF6'   �� 5�   
    � ��$	 305��6"   �� 5�   
    � ��$	 329��6#   5�      �� 5�      "  ��6%   .�5�   
   ��  �@J�Opacity$ 1Q�6$   �� 5�   
    � �� �#092C526/   �� 5�   
    � ��$ 20(�6%   �� 5�   
    � ��$	 210��6"   �� 5�   
    � ��$ Center=�60   �� 5�   
    � ��$ Center=�6.   5�      5�      