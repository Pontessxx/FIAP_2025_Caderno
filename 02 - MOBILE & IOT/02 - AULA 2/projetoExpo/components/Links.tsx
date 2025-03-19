import {useCallback} from 'react';
import {Alert, Button, Linking, View} from 'react-native';
const supportedURL = 'https://google.com';
const unsupportedURL = 'slack://open?team=123456';
type ButtonProps = {url: string; title: string};
const OpenURLButton = ({url, title}: ButtonProps) => {
const handleClick = useCallback(async () => {
const supported = await Linking.canOpenURL(url);
if (supported) {
await Linking.openURL(url);
} else {
Alert.alert(`Don't know how to handle this URL: ${url}`);
}
}, [url]);
return <Button title={title} onPress={handleClick} />;
};
const Links = () => {
return (
<View>
<OpenURLButton title="Open Supported URL" url={supportedURL} />
<OpenURLButton title="Open Unsupported URL" url={unsupportedURL} />
</View>
);
};
export default Links;