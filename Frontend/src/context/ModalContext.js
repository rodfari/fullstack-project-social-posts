import { createContext } from "react";

export const ModalContext = createContext({
    modal: false,
    setModal: () => {},
    toggleModal: () => {},
});