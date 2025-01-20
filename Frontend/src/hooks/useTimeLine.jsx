import { useEffect, useState } from "react";
import { useReducer } from "react";
import { getPosts } from "../services/api-services";

const ActionTypes = {
  SET_PAGE: "SET_PAGE",
  SET_PAGE_SIZE: "SET_PAGE_SIZE",
  SET_TOTAL: "SET_TOTAL",
  SET_SORT: "SET_SORT",
  SET_SEARCH: "SET_SEARCH",
};

const reducer = (state, action) => {
  switch (action.type) {
    case ActionTypes.SET_PAGE:
      return { ...state, page: action.payload };
    case ActionTypes.SET_PAGE_SIZE:
      return { ...state, pageSize: action.payload };
    case ActionTypes.SET_TOTAL:
      return { ...state, total: action.payload };
    case ActionTypes.SET_SORT:
      return { ...state, sort: action.payload };
    case ActionTypes.SET_SEARCH:
      return { ...state, search: action.payload };
    default:
      return state;
  }
};

const initialState = {
  page: 1,
  pageSize: 15,
  total: 0,
  sort: "desc",
  search: "",
};

export const useTimeLine = () => {
    const [hasMore, setHasMore] = useState(true);
    const [posts, setPosts] = useState([]);
    const [refresh, setRefresh] = useState(false);
    const [state, dispatcher] = useReducer(reducer, initialState);
    const [total] = useReducer(0);

    useEffect(() => {
      console.log("effect");
      getPosts(state.page, 
        state.pageSize, 
        state.search, state.sort).then(
        (request) => {
          if (request.data.length === 0) return;
          setPosts((prev) => {
            if (state.page < 2) return request.data;
            const arr = [...prev, ...request.data];

            return arr;
          });
        }
      );
    }, [state.page, state.pageSize, state.search, state.sort, refresh]);
    
    if((total - 1 ) <= posts.length) {
      setHasMore(false);
    }

    return {
        actions: ActionTypes,
        setParam: dispatcher,
        params: state,
        posts,
        hasMore,
        refresh,
        setRefresh,
        forceRefresh: () => setRefresh((prev) => !prev)
    };
};
