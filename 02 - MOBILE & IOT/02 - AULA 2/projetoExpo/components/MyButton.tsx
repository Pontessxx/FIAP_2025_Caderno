import {Button} from 'react-native';
const MyButton = () => {
return (
<Button title="My button" onPress={() => console.log('Button clicked')} />
);
};
export default MyButton;