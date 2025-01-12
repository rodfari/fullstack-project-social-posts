
import { createContext } from 'react'

export const AppContext = createContext({
    toggleModal: () => {},
    setUpdatePost: () => {},
    updatePost: false,
    sort: "newest",
    setSort: () => {},
    search: "",
    setSearch: () => {},
    repost: () => {},
    setRepost: () => {},
    user: {},
    setUser: () => {},
    currentUser: {},
    setCurrentUser: () => {},
});