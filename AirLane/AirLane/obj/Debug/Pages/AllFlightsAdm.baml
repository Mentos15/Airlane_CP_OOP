   M S B A M L   `   `   `  ����B  >AirLane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AirLane.PagesAirLane.Pages  5      !    AirLane.Pages.AllFlightsAdm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AirLane.Pages     5        N� Title$  AllFlightsAdm��5	      .��5      � .+�5   
   �� $��Обновить��6   $��80��6$   $��40��6/   $	��Top=�6;   $��-200 20 0 0q�6S   ��6h   �� *Reload+�� 5   
   $��Удалить��6   $��80��6#   $��40��6.   $	��Top=�6:   $��
200 20 0 0q�6R   ��6f   �� *Delete+�� 5   
    � DataContext 6   �� *Models+.+�5      � $��
5 100 10 0q�6   $��18��6'   
�������$	��Top=�6K    � ColumnDefinitions 5      �� 5      $��80 �6'   �� 5      $��80 �6'   �� 5      $	��100 �6'   �� 5      $	��100 �6'   �� 5      $��80 �6'   �� 5      $	��100 �6'   �� 5      $	��100 �6'   �� 5      $	��100 �6'   .+�5      �� $��Center=�6   $��0��69   $��Дата вылета��6I   �� 5      $��Center=�6   $��1��69   $��Дата прилета��6I   �� 5      $��Center=�6   $��2��69   $��От куда��6I   �� 5      $��Center=�6   $��3��69   $��Куда��6I   �� 5      $��Center=�6   $��4��69   $��Компания��6I   �� 5      $��Center=�6   $��5��69   $��Стоимость $��6I   �� 5       $��Center=�6   $��6��69   $��
Класс��6I   �� 5!      $��Center=�6   $��7��69   $��Осталось мест��6I   5"      &   System.Windows.Controls.DataGrid  5#      -   5          Name$ dataGrid��5#   s      HeadersVisibility$
 None=�6      CanUserAddRows .     CanUserDeleteRows .  $��5 0 10 0q�6a   $��1��6�      AutoGenerateColumns .     Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 5&   %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5%   )   �� *	DATE_FROM+5&   %     5'      $	 80 5(   %   
 5'   )   �� *	DATE_TO+5(   %     5)      $		 100 5*   %      
IsReadOnly . 
 5)   )   �� *
townFrom+5*   1     5+      $		 100 5,   %    . 
 5+   )   �� *townTo+5,   1     5-      $	 80 5.   %    . 
 5-   )   �� *	company+5.   0     5/      $		 100 50   %    . 
 5/   )   �� *price+50   1     51      $		 100 52   %    . 
 51   )   �� *clas+52   1     53      $	 * 54   %    . 
 53   )   �� *count_of_seats+54   /   56      57      58      59      