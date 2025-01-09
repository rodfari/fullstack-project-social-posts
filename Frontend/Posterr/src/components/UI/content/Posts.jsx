const Posts = ({ data }) => {
  return (
    <>
      {data.map((post) => (
        <div className="post-box" key={post.postId}>
          <div className="post">
            <div className="post__user">
              <div className="post__user-avatar">
                {post.userName.charAt(0).toUpperCase()}
              </div>
              <div className="post__user-name">{post.userName}</div>
            </div>
            <div className="post__content">
              <p>{post.content}</p>
            </div>
            <div className="post__date">
              <p>{post.createdAt}</p>
            </div>
          </div>
          <button>Repost</button>
        </div>
      ))}
    </>
  );
};

export default Posts;
