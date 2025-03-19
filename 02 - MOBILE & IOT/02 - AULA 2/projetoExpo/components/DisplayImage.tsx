import React from 'react';
import {Image} from 'react-native';
const DisplayImage = () => {
return (
    <>
        <Image
            style={{width: 50, height: 50}}
            source={{uri: 'https://reactnative.dev/img/tiny_logo.png'}}
        />
        <Image
            style={{width: 66, height: 58}}
            source={{uri: 'https://reactnative.dev/img/tiny_logo.png'}}
        />
    </>
    );
};
export default DisplayImage;
