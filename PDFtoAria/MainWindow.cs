<Window x:Class="PDFtoAria.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
        xmlns:cm="clr-namespace:System.ComponentModel;assembly=WindowsBase"
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
        mc:Ignorable="d" 
        Height="500" Width="800">
    <Window.Resources>
        <CollectionViewSource x:Key="Files" Source="{Binding Files}">
            <CollectionViewSource.SortDescriptions>
                <cm:SortDescription PropertyName="CreationTime" Direction="Ascending"/>
            </CollectionViewSource.SortDescriptions>
        </CollectionViewSource>
    </Window.Resources>
    <i:Interaction.Triggers>
        <i:EventTrigger EventName="Loaded">
            <i:InvokeCommandAction Command="{Binding GetFilesCommand}" />
        </i:EventTrigger>
    </i:Interaction.Triggers>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="2*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Grid Grid.Column="0">
            <StackPanel>
                <TextBlock Text="PDFs in directory:" HorizontalAlignment="Left" />
                <Button Content="Refresh" HorizontalAlignment="Right" Command="{Binding GetFilesCommand}"/>
                <ListBox 
                     DockPanel.Dock="Top"
                     ItemsSource="{Binding Source = {StaticResource Files}}"
                     SelectionMode="Multiple"
                     >
                    <ListBox.ItemContainerStyle>
                        <Style TargetType="{x:Type ListBoxItem}">
                            <Setter Property="IsSelected" Value="{Binding Mode=TwoWay, Path=IsSelected}"/>
                        </Style>
                    </ListBox.ItemContainerStyle>
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding FileNameWithCreationTime}"/>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
                <TextBlock Name="directory" Text="{Binding Directory}" TextWrapping="Wrap"/>
                <Button Content="Change folder" HorizontalAlignment="Right" Command="{Binding ChangeDirectoryCommand}"/>
            </StackPanel>
        </Grid>
        <Grid Grid.Column="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="3*"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <Grid Grid.Column="0">
                <Grid.RowDefinitions>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="*"/>
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="3*"/>
                    <ColumnDefinition Width="4*"/>
                </Grid.ColumnDefinitions>
                <Label Content="Patient ID:" VerticalAlignment="Center" Height="30" Grid.Row="0" Grid.Column="0"/>
                <Label Content="Date of service:" VerticalAlignment="Center" Height="30" Grid.Row="1" Grid.Column="0"/>
                <Label Content="Date entered:" VerticalAlignment="Center" Height="30" Grid.Row="2" Grid.Column="0"/>
                <Label Content="Authored by:" VerticalAlignment="Center" Height="30" Grid.Row="3" Grid.Column="0"/>
                <Label Content="Supervised by:" VerticalAlignment="Center" Height="30" Grid.Row="4" Grid.Column="0"/>
                <Label Content="Entered by:" VerticalAlignment="Center" Height="30" Grid.Row="5" Grid.Column="0"/>
                <Label Content="Document type:" VerticalAlignment="Center" Height="30" Grid.Row="6" Grid.Column="0"/>
                <Label Content="Template name:" VerticalAlignment="Center" Height="30" Grid.Row="7" Grid.Column="0"/>
                <TextBox Grid.Row="0" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding PatientId}" x:Name="patientIdTextBox" />
                <TextBox Grid.Row="1" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding DateOfService}"/>
                <TextBox Grid.Row="2" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding DateEntered}"/>
                <TextBox Grid.Row="3" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding AuthoredByUser.SingleUserId}"/>
                <TextBox Grid.Row="4" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding EnteredByUser.SingleUserId}"/>
                <TextBox Grid.Row="5" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding SupervisedByUser.SingleUserId}"/>
                <TextBox Grid.Row="6" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding DocumentType.DocumentTypeDescription}"/>
                <TextBox Grid.Row="7" Grid.Column="1" VerticalAlignment="Center" Height="30" Text="{Binding TemplateName}" x:Name="templateNameTextBox"/>
            </Grid>
            <Grid Grid.Row="2">
                <Button Content="Upload PDF to Aria" Width="150" Height="30" Margin="15" HorizontalAlignment="Right" Command="{Binding UploadToAriaCommand}"/>
            </Grid>
        </Grid>
    </Grid>
</Window>