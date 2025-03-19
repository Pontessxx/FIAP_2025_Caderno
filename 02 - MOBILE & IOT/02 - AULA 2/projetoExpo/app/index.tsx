import DisplayImage from "@/components/DisplayImage";
import Links from "@/components/Links";
import Loading from "@/components/Loading";
import MyAnimation from "@/components/MyAnimation";
import MyButton from "@/components/MyButton";
import MyDialog from "@/components/MyDialog";
import MyList from "@/components/MyList";
import MyModal from "@/components/MyModal";
import MyPressable from "@/components/MyPressable";
import MySectionList from "@/components/MySectionList";
import ScrollExample from "@/components/ScrollExample";
import TextInputExample from "@/components/TextInputExample";
import { Text, View } from "react-native";

export default function Index() {
  return (
    <View
      style={{
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Text>Edit app/index.tsx to edit this screen.</Text>
      <DisplayImage />
      <Links />
      <Loading />
      <MyAnimation/>
      <MyButton/>
      <MyDialog/>
      <MyList/>
      <MyModal/>
      <MyPressable/>
      <MySectionList/>
      <ScrollExample/>
      <TextInputExample/>
    </View>
  );
}
