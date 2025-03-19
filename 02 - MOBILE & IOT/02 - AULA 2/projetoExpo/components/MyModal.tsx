import {useState} from 'react';
import {View, Modal, Text, Button, StyleSheet} from 'react-native';
const MyModal = () => {
const [isVisible, setIsVisible] = useState(false);
    const onModalClosed = () => {
    setIsVisible(false);
    };
    const styles = StyleSheet.create({
        centeredView: {
        flex: 1,
        justifyContent: 'center'
        ,
        alignItems: 'center'
        ,
        marginTop: 22,
        },
        modalView: {
        margin: 20,
        backgroundColor: 'white'
        ,
        borderRadius: 20,
        padding: 35,
        alignItems: 'center'
        ,
        shadowColor: '#000'
        ,
        shadowOffset: {
        height: 2,
        width: 0,
        },
        },
        textStyle: {
        fontWeight: 'bold'
        ,
        textAlign: 'center'
        ,
        },
    });
return (
    <View style={styles.centeredView}>
    <Modal
    animationType="slide"
    transparent={true}
    visible={isVisible}
    onRequestClose={onModalClosed}>
    <View style={[styles.centeredView, styles.modalView]}>
    <Text style={styles.textStyle}>Hello world!</Text>
    <Button title="Close Modal" onPress={onModalClosed} />
    </View>
    </Modal>
    <Button title="Show Modal" onPress={() => setIsVisible(true)} />
    </View>
);
};
export default MyModal;