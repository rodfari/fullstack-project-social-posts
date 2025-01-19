import Modal from "../components/Modal";
import { useState } from "react";

export const useModal = () => {  
    const [modal, setModal] = useState(false);
    const toggleModal = () => {
        setModal((prev) => (prev ? false : true));
    };
    const element = <Modal />;
    return { modal, toggleModal, element };
};