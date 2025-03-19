import {View, Alert, Button} from 'react-native';
const showDialog = () => {
Alert.alert('Alert title', 'My alert message', [
{
text: 'Cancel',
onPress: () => console.log('Cancel pressed'),
style: 'cancel',
},
{text: 'OK', onPress: () => console.log('OK pressed')},
]);
};
const showDestructiveDialog = () => {
Alert.alert('Alert title', 'My alert message', [
{
text: 'Cancel',
onPress: () => console.log('Cancel pressed'),
style: 'cancel',
},
{
text: 'Close',
onPress: () => console.log('Close pressed'),
style: 'destructive',
},
{text: 'OK', onPress: () => console.log('OK pressed')},
]);
};
const MyDialog = () => {
return (
<View>
<Button title="2-Button alert" onPress={showDialog} />
<Button title="3-Button alert" onPress={showDestructiveDialog} />
</View>
);
};
export default MyDialog;
