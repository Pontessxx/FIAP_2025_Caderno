import React from 'react';
import {TextInput, Text} from 'react-native';
const TextInputExample = () => {
const [text, onChangeText] = React.useState('Useless text');
const [number, onChangeNumber] = React.useState('');
return (
    <>
        <TextInput
            style={{height: 40, margin: 12, borderWidth: 1}}
            onChangeText={onChangeText}
            value={text}
        />
        <Text>Text: {text}</Text>
        <TextInput
            style={{height: 40, margin: 12, borderWidth: 1}}
            onChangeText={onChangeNumber}
            value={number}
            placeholder="useless placeholder"
            keyboardType="numeric"
        />
        <Text>Number: {number}</Text>
    </>
);
};
export default TextInputExample;