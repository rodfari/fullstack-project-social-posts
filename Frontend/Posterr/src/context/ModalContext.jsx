
import { createContext } from 'react'

export const ModalContext = createContext({
    toggleModal: () => {},
    setUpdatePost: () => {},
    updatePost: false
});