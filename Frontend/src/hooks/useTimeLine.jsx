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
  console.log("action called")
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

export const useTimeLine = (requestParams, timeLineContext) => {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [hasMore, setHasMore] = useState(false);
    const [posts, setPosts] = useState([]);
    const [refresh, setRefresh] = useState(false);
    //debugger
    const [state, dispatcher] = useReducer(reducer, initialState);

    useEffect(() => {
      console.log("params has changed");
      console.log(state);
      getPosts(state.page, 
        state.pageSize, 
        state.search, state.sort).then(
        (request) => {
          if (request.data.length === 0) return;
          setPosts((prev) => {
            if (state.page < 2) return request.data;
            return [...prev, ...request.data];
          });
        }
      );
    }, [state.page, state.pageSize, state.search, state.sort, refresh]);


    return {
        actions: ActionTypes,
        setParam: dispatcher,
        params: state,
        isLoading,
        posts,
        error,
        hasMore,
        refresh,
        setRefresh,
        forceRefresh: () => setRefresh((prev) => !prev),
    };
};
