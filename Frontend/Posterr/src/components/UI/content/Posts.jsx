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
              <p>{post.createdAt}</p>
            </div>
            <div className="post__repost">
              <button>Repost</button>
            </div>
          </div>
        </div>
      ))}
    </>
  );
};

export default Posts;
