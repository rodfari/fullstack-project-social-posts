
import { createContext } from 'react'

export const AppContext = createContext({
    page: 1,
    setPage: () => {},
    pageSize: 15,
    setPageSize: () => {},
    toggleModal: () => {},
    setUpdatePost: () => {},
    updatePost: false,
    sort: "newest",
    setSort: () => {},
    search: "",
    setSearch: () => {},
    repost: () => {},
    setRepost: () => {}
});