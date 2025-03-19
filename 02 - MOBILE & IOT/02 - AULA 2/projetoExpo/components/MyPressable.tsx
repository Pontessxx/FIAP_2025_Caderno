import {Pressable, Text} from 'react-native';
const MyPressable = () => {
const onPressIn = () => console.log('Pressed in');
const onPressOut = () => console.log('Pressed out');
const onLongPress = () => console.log('Long press');
return (
<Pressable
onPressIn={onPressIn}
onPressOut={onPressOut}
onLongPress={onLongPress}>
<Text>I'm clickable</Text>
</Pressable>
);
};
export default MyPressable;
